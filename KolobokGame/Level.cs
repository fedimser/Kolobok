using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Media;


namespace KolobokGame
{
    public delegate void DefaultHandler();


    class Level
    {
        

        public Size Size;
        public string level_name="The Level";
        public string BGTrack = "Track01.mp3";

        //State
        float time;
        public int Score;

        bool isGame;


        //Physics 
        public float gravity = 500F;

        //Camera
        public Size CameraSize;
        public float Scale = 1;
        public PointF CameraPos;
        public PointF StartPosition= new Point(0,0);

        public   List<GameObject> objs = new List<GameObject>();
        public List<GameObject> objsToRemove = new List<GameObject>();
        public List<Creature> creatures = new List<Creature>();
        public List<Creature> crsToRemove = new List<Creature>();
        public Creature Kolobok;


        //Design
        public int design_mode = 0;

        public enum Actions
        {
            GoRight,
            GoLeft,
            Jump,
            Down,
            Shut, 
            Cheat,
            Fuck
        }


        public event DefaultHandler GameOver;
        public event DefaultHandler LevelComplete;




        public Level(Size LevelSize,Size CamSize)
        {
            CameraSize = CamSize;
            Size = LevelSize;
            CameraPos = new Point(0, 0);
        }

        public Level(string file, Size CamSize)
        {
            CameraSize = CamSize;
            Size = new Size(500, 500);
            CameraPos = new Point(0, 0);
            var rdr = new StreamReader(file);

            string line;
            do
            {
                line = rdr.ReadLine();
                if (line == null) throw new Exception("Empty File");
            } while (line == "" || line[0] == '/');

            string[] str = line.Split(' ');
            Size = new Size(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));


            //line = rdr.ReadLine();
            //int n = Convert.ToInt32(line);

            for ( ; ; )
            {
                do
                {
                    line = rdr.ReadLine();
                    if (line == null) break;
                }while(line=="" || line[0]=='/');
                if (line == null) break;

                if (line.IndexOf("/") >= 0) line = line.Substring(0, line.IndexOf("/"));

                str = line.Split(' ');
                int obT;

                try
                {
                    obT = Convert.ToInt32(str[0]);

                    if (obT < 10)
                    {
                        GameObject obj = new GameObject((GameObject.type)obT);

                        if (obj.tp == GameObject.type.Coin || obj.tp == GameObject.type.Drug)
                        {
                            obj.rect = new Rectangle(Convert.ToInt32(str[1]) - 20, Convert.ToInt32(str[2]) - 20, 20, 20);
                        }
                        else
                        {
                            obj.rect = new Rectangle(Convert.ToInt32(str[1]), Convert.ToInt32(str[2]), Convert.ToInt32(str[3]), Convert.ToInt32(str[4]));
                        }


                        if (obj.tp == GameObject.type.Block || obj.tp == GameObject.type.Block)
                        {
                            obj.Color = RandomColor();
                        }

                        if (obj.tp == GameObject.type.MovingBlock)
                        {
                            obj.p1 = new Point(Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
                            obj.p2 = new Point(Convert.ToInt32(str[5]), Convert.ToInt32(str[6]));
                            obj.anim_cycle = 10;
                        }
                        objs.Add(obj);

                    }
                    else if (obT == 10)
                    {
                        StartPosition = new PointF(Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
                    }
                    else
                    {
                        PointF Loc = new PointF(Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
                        Creature obj = new Creature((Creature.type)(obT - 10), Loc,this);

                        creatures.Add(obj);
                    }

                }
                catch
                { continue; }
            }

            rdr.Close();

            Kolobok = new Creature(Creature.type.Kolobok,this.StartPosition,this);//(CamSize.Width/2,CamSize.Height/2));
            FitCamera();
        }

        public void initGame()
        {
            time = 0; 
            isGame = true;

        //    for (int i = 1; i <= 200; i++)
        //        AddRandomCreature();

            playBGTrack(BGTrack);
            DrawTitle_percent = 255;
        }

       

        private void FitCamera()
        {
            PointF KC = Kolobok.Center();
            CameraPos = new PointF(KC.X - CameraSize.Width / 2, KC.Y - CameraSize.Height / 2);

        }

        public void MoveCamera(float dx, float dy)
        {
            CameraPos = new PointF(CameraPos.X + dx, CameraPos.Y + dy);
        }

        public void Action(Actions action, bool release)
        {
            switch (action)
            {
                case Actions.GoLeft:
                    
                    if (!release)
                    {
                        if (Kolobok.velX > 0) return;
                        Kolobok.velX = -Kolobok.maxHorVel;
                        Kolobok.view_side = -1;
                    }
                    else
                    {
                        Kolobok.velX = 0;
                    }
                    break;

                case Actions.GoRight:
              
                    if (!release)
                    {
                        if (Kolobok.velX < 0) return;
                        Kolobok.velX = Kolobok.maxHorVel;
                        Kolobok.view_side = +1;
                    }
                    else
                    {
                        Kolobok.velX = 0;
                    }
                    break;

                case Actions.Jump:
                    if (!release)
                    {

                        if (Kolobok.isOnGround)
                        {
                            Kolobok.isOnGround = false;
                            Kolobok.velY = -Kolobok.maxVertVel;


                            playSound(Properties.Resources.Jump);
                        }
                    }
                    else
                    {

                    }
                    break;

                case Actions.Down:
                    if (!release)
                    {
                        Kolobok.gravityK = 3;
                    }
                    else
                    {
                        Kolobok.gravityK = 1;
                    }
                    break;

                case Actions.Shut:
                    if (!release)
                    {
                        KolobokShut();
                    }
                    else
                    {

                    }
                    break;

                case Actions.Cheat:
                   // gameOver(true);
                    break;
            }

        }

#region "EditMode"
         
        private const int EditMode_GridStep=25;
        public bool EditMode = false;
        public bool EditMode_Grid = false;
        public void EditMode_Draw(ref PictureBox pb)
        {
            Bitmap bmp = new Bitmap(CameraSize.Width, CameraSize.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Matrix trns = new Matrix();
            trns.Translate(-CameraPos.X, -CameraPos.Y);
            trns.Scale(Scale, Scale);
            g.Transform = trns;

            if (EditMode_Grid)
            {
                int step = EditMode_GridStep;
                for (int i = 1; i < Size.Width / step; i++) g.DrawLine(Pens.Gray, step * i, 0, step * i, Size.Height);
                for (int i = 1; i < Size.Height / step; i++) g.DrawLine(Pens.Gray, 0, step * i, Size.Width, step * i);
            }

            Kolobok.Draw(ref g);
            foreach (Creature i in creatures) i.Draw(ref g);
            foreach (GameObject i in objs) i.DrawEditMode(ref g);


            //KOLOBOK FUCK FUCK

            g.DrawRectangle(new Pen(Color.Black, 3), 0, 0, Size.Width, Size.Height);

           
            g.Transform = new Matrix();
            if (DrawTitle_percent > 0) DrawTitle(ref g);

            pb.Image = bmp;
        }

        private int EditMode_AllignGrid(int x)
        {
            return EditMode_GridStep * ((x + (EditMode_GridStep / 2)) / EditMode_GridStep);
        }

        public void AddObject(GameObject obj)
        {
            if (EditMode_Grid)
            {
                int x1 = EditMode_AllignGrid(obj.rect.Left);
                int x2 = EditMode_AllignGrid(obj.rect.Right);
                int y1 = EditMode_AllignGrid(obj.rect.Top);
                int y2 = EditMode_AllignGrid(obj.rect.Bottom);
                obj.rect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                obj.p1 = new Point(x1, y1);
                obj.p2 = new Point(EditMode_AllignGrid(obj.p2.X), EditMode_AllignGrid(obj.p2.Y));
                if (x1 == x2 || y1 == y2) return;
            }
           
            objs.Add(obj);
        }

        public void AddCreature(Creature obj)
        { 
            creatures.Add(obj);
        }

        public void EditMode_RemoveByPoint(PointF pnt)
        {
            objsToRemove = new List<GameObject>();
            crsToRemove=new List<Creature>();

            foreach (GameObject i in objs)
            { 
                if (i.hitTest(pnt)) objsToRemove.Add(i);
            }

            foreach (Creature i in creatures)
            { 
                if (i.hitTest(pnt)) crsToRemove.Add(i);
            }

            foreach (GameObject i in objsToRemove)
            {
                objs.Remove(i);
            }

            foreach (Creature i in crsToRemove)
            {
                creatures.Remove(i);
            }

        }

        #endregion

        public void Draw(ref PictureBox pb)
        {
            Bitmap bmp = new Bitmap(CameraSize.Width, CameraSize.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Matrix trns = new Matrix();
            trns.Translate(-CameraPos.X, -CameraPos.Y);
            g.Transform = trns;

                      

            Kolobok.Draw(ref g);
            foreach (Creature i in creatures) i.Draw(ref g);
            foreach (GameObject i in objs) i.Draw(ref g);

            g.Transform=new Matrix();
            if (DrawTitle_percent > 0) DrawTitle(ref g);

            pb.Image = bmp;


        }

        public void Live(float dt)
        {
            if (!isGame) return;

            time += dt;

            Kolobok.Live(dt);

            foreach (GameObject j in objsToRemove)
            {
                objs.Remove(j);
            }
            objsToRemove.Clear();

            foreach (Creature j in crsToRemove)
            {
                creatures.Remove(j);
            }
            crsToRemove.Clear();

            PointF KC = Kolobok.Center();
            PointF KolVisPos = new PointF(KC.X - CameraPos.X, KC.Y - CameraPos.Y);

            if (KolVisPos.X < 0.25 * CameraSize.Width) CameraPos.X = (float)(KC.X - 0.25 * CameraSize.Width);
            if (KolVisPos.X > 0.75 * CameraSize.Width) CameraPos.X = (float)(KC.X - 0.75 * CameraSize.Width);

            if (KolVisPos.Y < 0.25 * CameraSize.Height) CameraPos.Y = (float)(KC.Y - 0.25 * CameraSize.Height);
            if (KolVisPos.Y > 0.75 * CameraSize.Height) CameraPos.Y = (float)(KC.Y- 0.75 * CameraSize.Height);
           


            foreach (Creature i in creatures)
            {
                i.Live(dt);
            }


            foreach (GameObject i in objs)
            {
                i.Live(dt);
            }

            if (Kolobok.pos.Bottom > this.Size.Height)
            {
                gameOver(false);
            }

            TitleFade(1);
        }
 

        private void KolobokShut()
        {
            playSound(Properties.Resources.Shot);

            Creature bullet = new Creature(Creature.type.Bullet, Kolobok.Center(),this);
            bullet.life = 1;
            bullet.gravityK = 0.1F;
            bullet.velX = 1000*Kolobok.view_side;
            creatures.Add(bullet);

        }

        SoundPlayer player = new SoundPlayer();
        public void playSound(Stream str)
        {
            player.Stream = str;
            player.Load();
            player.Play();
        }


      


        public void gameOver(bool win)
        {
            isGame = false;

            BGPlayer.Close();

            if (win)
            {
               // playSound(Properties.Resources.LevelComplete);
                LevelComplete();
            }
            else
            {
                playSound(Properties.Resources.GameOver);
                GameOver();
            }
        }


        public  Random rnd = new Random();
        public  Color RandomColor()
        {
            return Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

         private  void AddRandomCreature()
        {
            PointF loc = new PointF((float)(rnd.NextDouble() * Size.Width),(float)( rnd.NextDouble() * Size.Height));
            Creature cr = new Creature(Creature.type.Fox,loc,this);

            creatures.Add(cr);
        }


         public string Info(    )
         {
           return  Kolobok.Center().ToString() + " " + "Score= " + Score + " Life=" + Kolobok.life;
         }

         public void DrugEaten()
         {
             foreach (GameObject obj in objs)
             {
                 if (obj.tp == GameObject.type.Block || obj.tp == GameObject.type.MovingBlock) obj.Color = RandomColor();
             }

         }

        #region "Backround Music"
            public  Media.Player BGPlayer = Media.Player.GetPlayer();
            private bool isPlayingMusic = false;
        
            private void playBGTrack(string track)
             {
                 isPlayingMusic = true;
                BGPlayer = new Media.Player();

                string path = Application.StartupPath + "\\Music\\" + track;
                try
                {
                    BGPlayer.Open(path);
                }
                catch (Exception)
                {
                    return;
                }
               
                BGPlayer.Play(true);
                BGPlayer.MasterVolume = 10;
             }

            public void StopMusic()
            {
                 if(isPlayingMusic)   BGPlayer.Close();
            }
        #endregion


            public void SaveToFile(string Filename)
            {
                 
                

                string str="";
                str += string.Format("//KolobokGame Level. Created Automatically. Time: [{0}]\n", DateTime.Now.ToString());
                str += string.Format("{0} {1}\n", Size.Width, Size.Height);

                foreach (Creature i in creatures) str += i.ToString() + "\n";
                foreach (GameObject i in objs) str += i.ToString() + "\n";
                str += Kolobok.ToString() + "\n";
                File.WriteAllText(Filename, str);
            }


        #region "Level Title"
        
            int DrawTitle_percent;
            private void DrawTitle(ref Graphics g)
            {
                if (DrawTitle_percent <= 0) return;
                var brsh = new SolidBrush(Color.FromArgb(DrawTitle_percent, 0, 0, 0));
                var fnt=new Font("Arial Black",40);
                var pnt = new PointF(  (float)(CameraSize.Width/2)-100F  ,  (float)(CameraSize.Height /2) );
                g.DrawString(this.level_name,fnt,brsh,pnt);
            }

            private void TitleFade(int pc)
            {
                if (DrawTitle_percent <= 0) return;
                DrawTitle_percent -= pc;
            }
     
        #endregion
    }
}
