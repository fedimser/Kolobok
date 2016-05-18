using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KolobokGame
{
    public partial class LevelEditor : Form
    {
        Level lev;
        private bool LOADED_FLAG=false;
         
        public LevelEditor()
        {
            InitializeComponent();
        }

        private void LevelEditor_Load(object sender, EventArgs e)
        {
            button4.PerformClick();
             

            LOADED_FLAG = true;
        }

        public void LoadLevel(string FileName)
        {
            lev = new Level(FileName, pictureBox1.Size);
            numericUpDown1.Value = lev.Size.Width;
            numericUpDown2.Value = lev.Size.Height;
            lev.EditMode = true;
            timer1.Start();
        }

        //save level to file
        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "DAT files|*.dat";
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lev.SaveToFile(sfd.FileName);
            }
        }

        //Load Level form file
        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "DAT files|*.dat";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadLevel(ofd.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (NRST)
            {
                MousePressed = false;
                nowAddingMB = false;
                NRST = false;
            }

            lev.EditMode_Draw(ref pictureBox1);

            if (MousePressed)
            {
                var npnt = MouseCoord();
                if (rb_Move.Checked)
                {
                    lev.MoveCamera(pnt.X- npnt.X, pnt.Y - npnt.Y);

                    pnt = npnt;
                }
 

                if (drawRct()  && !nowAddingMB)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.DrawRectangle(Pens.Black, Math.Min(pnt.X, npnt.X), Math.Min(pnt.Y, npnt.Y), Math.Abs(npnt.X - pnt.X), Math.Abs(npnt.Y - pnt.Y));
                }

               
                
            }

            if (nowAddingMB)
            {
                var npnt = MouseCoord();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawRectangle(Pens.Black, MBRect);
                int dx = npnt.X - MBRect.X - MBRect.Width / 2;
                int dy = npnt.Y - MBRect.Y - MBRect.Height / 2;
                Rectangle rect2 = new Rectangle(MBRect.X + dx, MBRect.Y + dy, MBRect.Width, MBRect.Height);
                g.DrawRectangle(Pens.Black, rect2);
                g.DrawLine(Pens.Black, MBRect.X + MBRect.Width / 2, MBRect.Y + MBRect.Height / 2, npnt.X, npnt.Y);
            }

            Point pnt1 = PointToClient(Cursor.Position);
            pnt1 = new Point(pnt1.X - groupBox3.Left, pnt1.Y - groupBox3.Top);
            HideControl(  groupBox2, pnt1); 

        }

        bool drawRct()
        {
            return rb_Block.Checked || rb_MobStopper.Checked || rb_movBlock.Checked || rb_Portal.Checked || rb_Jumper.Checked;
        }


        //New empty level
        private void button4_Click(object sender, EventArgs e)  
        {
            lev = new Level(pictureBox1.Size, pictureBox1.Size);
            lev.CameraSize = pictureBox1.Size;
            lev.Kolobok = new Creature(Creature.type.Kolobok, new PointF(30, 30),lev);
            numericUpDown1.Value = lev.Size.Width;
            numericUpDown2.Value = lev.Size.Height;
            lev.EditMode_Draw(ref pictureBox1);
            timer1.Start();
        }

        bool MousePressed = false;
        Point pnt;
        bool MouseOnPicture()
        {
            var pnt = PointToClient(Cursor.Position);
            return pnt.X > pictureBox1.Left && pnt.X < pictureBox1.Right && pnt.Y > pictureBox1.Top && pnt.Y < pictureBox1.Bottom;
        }

        private Point MouseCoord()
        {
            return new Point(PointToClient(Cursor.Position).X - pictureBox1.Location.X,PointToClient(Cursor.Position).Y - pictureBox1.Location.Y);        
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MousePressed = true;
            pnt = MouseCoord();
        }


        bool nowAddingMB = false;
        Rectangle MBRect;

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MousePressed = false;
            var npnt = MouseCoord();
            if (rb_Block.Checked)
            {
                GameObject obj = new GameObject(GameObject.type.Block);
                obj.rect = new Rectangle((int)((Math.Min(pnt.X, npnt.X) + lev.CameraPos.X) / lev.Scale), (int)((Math.Min(pnt.Y, npnt.Y)  + lev.CameraPos.Y)/ lev.Scale), (int)(Math.Abs(npnt.X - pnt.X) / lev.Scale), (int)(Math.Abs(npnt.Y - pnt.Y) / lev.Scale));
                obj.Color = lev.RandomColor();
                lev.AddObject(obj);            
            }

            if(rb_movBlock.Checked)
            {
                nowAddingMB = true;
                MBRect = new Rectangle( Math.Min(pnt.X, npnt.X) ,  Math.Min(pnt.Y, npnt.Y)  ,  Math.Abs(npnt.X - pnt.X) , Math.Abs(npnt.Y - pnt.Y)  );
            }


            if(rb_Jumper.Checked)
            {
                GameObject obj = new GameObject(GameObject.type.Jumper);
                obj.rect = new Rectangle((int)((Math.Min(pnt.X, npnt.X) + lev.CameraPos.X) / lev.Scale), (int)((Math.Min(pnt.Y, npnt.Y) + lev.CameraPos.Y) / lev.Scale), (int)(Math.Abs(npnt.X - pnt.X) / lev.Scale), (int)(Math.Abs(npnt.Y - pnt.Y) / lev.Scale));
                
                lev.AddObject(obj);
            }

             if(rb_MobStopper.Checked)
            {
                GameObject obj = new GameObject(GameObject.type.MobStopper);
                obj.rect = new Rectangle((int)((Math.Min(pnt.X, npnt.X) + lev.CameraPos.X) / lev.Scale), (int)((Math.Min(pnt.Y, npnt.Y) + lev.CameraPos.Y) / lev.Scale), (int)(Math.Abs(npnt.X - pnt.X) / lev.Scale), (int)(Math.Abs(npnt.Y - pnt.Y) / lev.Scale));
                
                lev.AddObject(obj);
            }

             if (rb_Portal.Checked)
             {
                 GameObject obj = new GameObject(GameObject.type.Portal);
                 obj.rect = new Rectangle((int)((Math.Min(pnt.X, npnt.X) + lev.CameraPos.X) / lev.Scale), (int)((Math.Min(pnt.Y, npnt.Y) + lev.CameraPos.Y) / lev.Scale), (int)(Math.Abs(npnt.X - pnt.X) / lev.Scale), (int)(Math.Abs(npnt.Y - pnt.Y) / lev.Scale));
                 
                 lev.AddObject(obj);
             }
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            MousePressed = false;
            nowAddingMB = false;
        }


        private void pictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!MouseOnPicture()) return;

            float eps = 0.01F;
            var pnt1=MouseCoord();

            if (e.Delta > 0)
            {
                lev.Scale += eps;
                lev.MoveCamera((eps / lev.Scale * (pnt1.X + lev.CameraPos.X)), (eps / lev.Scale * (pnt1.Y + lev.CameraPos.Y)));
            }

            if (e.Delta < 0)
            {
                lev.Scale -= eps;
                lev.MoveCamera(-(eps / lev.Scale * (pnt1.X + lev.CameraPos.X)), -(eps / lev.Scale * (pnt1.Y + lev.CameraPos.Y)));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lev.EditMode_Grid = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            if (!Directory.Exists(Application.StartupPath + "\\Temp")) Directory.CreateDirectory( Application.StartupPath + "\\Temp");
            lev.SaveToFile(Application.StartupPath + "\\Temp\\testlevel.dat");
            var w = new Form1();
            w.TestMode = true;
            
            w.TestLevel(Application.StartupPath + "\\Temp\\testlevel.dat");
            w.ShowDialog();
            w.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if (!LOADED_FLAG) return;
            lev.Size.Width = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            if (!LOADED_FLAG) return;
            lev.Size.Height = (int)numericUpDown2.Value;
        }

        void HideControl(  Control C, Point mp)
        {
            C.Enabled = (mp.X > C.Left && mp.X < C.Right && mp.Y > C.Top && mp.Y < C.Bottom);        
        }

        bool NRST = false;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var pnt = MouseCoord();
            var pnt_g = new Point((int)((pnt.X + lev.CameraPos.X) / lev.Scale),(int)( (pnt.Y + lev.CameraPos.Y) / lev.Scale));
            if (rb_Remove.Checked)
            { 

                lev.EditMode_RemoveByPoint(pnt_g);
            }

            if (  nowAddingMB)
            { 
                int dx = pnt.X - MBRect.X - MBRect.Width / 2;
                int dy = pnt.Y - MBRect.Y - MBRect.Height / 2;
                Rectangle rect2 = new Rectangle(MBRect.X + dx, MBRect.Y + dy, MBRect.Width, MBRect.Height);

                var obj = new GameObject(GameObject.type.MovingBlock);
                
                obj.rect = new Rectangle((int)((MBRect.X + lev.CameraPos.X) / lev.Scale), (int)((MBRect.Y + lev.CameraPos.Y)/ lev.Scale), (int)(MBRect.Width / lev.Scale), (int)(MBRect.Height/ lev.Scale));
                obj.p1 = new Point((int)((MBRect.X + lev.CameraPos.X) / lev.Scale), (int)((MBRect.Y + lev.CameraPos.Y) / lev.Scale));
                obj.p2 = new Point((int)((rect2.X + lev.CameraPos.X) / lev.Scale), (int)((rect2.Y + lev.CameraPos.Y) / lev.Scale));
                lev.AddObject(obj);


                NRST = true; 
            }

            if (rb_Coin.Checked)
            {
                var obj = new GameObject(GameObject.type.Coin);
                obj.rect = new Rectangle(pnt_g.X - 10, pnt_g.Y - 10, 2 * 10, 2 * 10);
                lev.AddObject(obj);
            }

            if (rb_Drug.Checked)
            {
                var obj = new GameObject(GameObject.type.Drug);
                obj.rect = new Rectangle(pnt_g.X - 10, pnt_g.Y - 10, 2 * 10, 2 *10);
                lev.AddObject(obj);
            }

            if (rb_Kolobok.Checked)
            {
                lev.Kolobok = new Creature(Creature.type.Kolobok, pnt_g,lev);
            }

            if (rb_Fox.Checked)
            {
                var obj = new Creature(Creature.type.Fox, pnt_g,lev);
                lev.AddCreature(obj);
            }

            if (rb_Rabbit.Checked)
            {
                var obj = new Creature(Creature.type.Rabbit, pnt_g,lev);
                lev.AddCreature(obj);
            }

            if (rb_Bear.Checked)
            {
                var obj = new Creature(Creature.type.Bear, pnt_g,lev);
                lev.AddCreature(obj);
            }

            if (rb_Wolf.Checked)
            {
                var obj = new Creature(Creature.type.Wolf, pnt_g,lev);
                lev.AddCreature(obj);
            }

        }

        
         
         
    }
}
