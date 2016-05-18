using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D; 

namespace KolobokGame
{
    class Creature
    {
        public const float KolobokRadius = 15;
        const int bullet_damage = 5;

        public RectangleF pos;
        public float velX = 0, velY = 0;
        public float maxHorVel;
        public float maxVertVel;

        public float gravityK=1F;

        public int life;
        public int scoreIncIfKilled; //for enemies

        public SByte view_side = 1;


        public bool isOnGround = false;

        Color Color = Color.Black;

        private GameObject BottomObj=null;

        public enum type
        {
            Kolobok,
            Fox,
            Rabbit,
            Bear,
            Wolf,
            Bullet
        }

        //Pointer to containing level
        Level lev=null;

        type tp;
        public Creature(type _type,PointF location, Level _lev)
        {
            switch (_type)
            {
                case type.Kolobok:
                    pos = new RectangleF(location.X - KolobokRadius, location.Y - KolobokRadius, 2 * KolobokRadius, 2 * KolobokRadius);
                    life = 100;
                    maxHorVel = 400;
                    maxVertVel = 400;
                    break;
                case type.Fox:
                    pos = new RectangleF(location.X - 20, location.Y - 20, 2 * 20, 2 * 20); maxHorVel = 400;
                    life = 5;
                    maxHorVel = 400;
                    maxVertVel = 300;
                    scoreIncIfKilled = 100;
                    break;
                case type.Rabbit:
                    pos = new RectangleF(location.X - 20, location.Y - 20, 2 * 20, 2 * 20); maxHorVel = 400;
                    life = 5;
                    maxHorVel = 300;
                    maxVertVel = 300;
                    scoreIncIfKilled = 50;
                    break;
                case type.Bear:
                    pos = new RectangleF(location.X - 20, location.Y - 20, 2 * 20, 2 * 20); maxHorVel = 400;
                    life = 5;
                    maxHorVel = 100;
                    maxVertVel = 300;
                    scoreIncIfKilled = 200;
                    break; 
                case type.Wolf:
                    pos = new RectangleF(location.X - 20, location.Y - 20, 2 * 20, 2 * 20); maxHorVel = 400;
                    life = 5;
                    maxHorVel = 200;
                    maxVertVel = 300;
                    scoreIncIfKilled = 150;
                    break;
                case type.Bullet:
                    pos = new RectangleF(location.X - 3, location.Y - 3, 2 * 3, 2 * 3);
                    life = 1;
                    break;
            }

            tp = _type;
            lev = _lev;
        }

        public void Draw(ref Graphics g)
        {
            int x = (int)pos.Left;
            int y = (int)pos.Top;
            Point[] pts;

            switch (tp)
            {
                case type.Kolobok  :


                    g.FillEllipse(Brushes.Black, pos);


                    if (lev.design_mode == 1488)
                    {
                        g.FillEllipse(Brushes.Yellow, pos);;
                        g.DrawEllipse(new Pen(Color.Black,3), pos.X + 1.05F * KolobokRadius, pos.Y + 0.3F * KolobokRadius, 0.66F * KolobokRadius, 0.66F * KolobokRadius);
                        g.FillEllipse(Brushes.White, pos.X+1.05F*KolobokRadius,pos.Y+0.3F*KolobokRadius,0.66F*KolobokRadius,0.66F*KolobokRadius);
                        g.FillEllipse(Brushes.Black, pos.X + 1.25F * KolobokRadius, pos.Y + 0.5F * KolobokRadius, 0.26F * KolobokRadius, 0.26F * KolobokRadius);

                        for (float dx = -KolobokRadius; dx <= 0; dx += 2.0F)
                        {
                            g.DrawLine(Pens.Black, pos.X + KolobokRadius+dx, pos.Y, pos.X + 0.5F * KolobokRadius+dx, pos.Y + KolobokRadius);
                        }
                        g.FillRectangle(Brushes.Black, pos.X + 0.7F * KolobokRadius,pos.Y + 1.2F * KolobokRadius,  0.6F * KolobokRadius, 0.2F * KolobokRadius);
                        g.DrawArc(new Pen(Color.Black, 1), new RectangleF(pos.X + 0.55F*KolobokRadius, pos.Y + 1.0F * KolobokRadius, 0.9F * KolobokRadius, 0.9F * KolobokRadius),20,140);
                    }

                    break;
                case type.Bullet:
                     g.FillEllipse(Brushes.Black, pos);

                     if (lev.design_mode == 1488)
                     {
                         float bx = pos.X + 0.5F * pos.Width;
                         float by = pos.Y + 0.5F * pos.Height;
                         float ang = 5 * bx;

                         Matrix rt = g.Transform;
                         rt.RotateAt(ang, new PointF(bx, by));
                         g.Transform = rt;

                         g.DrawLine(Pens.Black, bx, by, bx + 10, by);
                         g.DrawLine(Pens.Black, bx, by, bx - 10, by);
                         g.DrawLine(Pens.Black, bx,by, bx , by+10);
                         g.DrawLine(Pens.Black, bx, by, bx , by-10);
                         g.DrawLine(Pens.Black, bx+10, by,bx + 10, by+10);
                         g.DrawLine(Pens.Black, bx-10, by, bx -10, by-10);
                         g.DrawLine(Pens.Black, bx, by+10, bx-10, by + 10);
                         g.DrawLine(Pens.Black, bx, by-10, bx+10, by - 10);

                         rt.RotateAt(-ang, new PointF(bx, by));
                         g.Transform = rt ;

                     }

                    break;
                case type.Fox: 
                    pts=new Point[7];
                    

                    pts[0] = new Point(x, y);
                    pts[1] = new Point(x + 10, y - 10);
                    pts[2] = new Point(x + 20, y);
                    pts[3]=  new Point(x + 30,y-10);
                    pts[4] = new Point(x + 40, y);
                    pts[5] = new Point(x + 20, y + 40);
                    pts[6] = new Point(x, y);
                  
                    g.FillPolygon(Brushes.Red, pts);

                    g.FillEllipse(Brushes.Black, x+11,y+10,8,8);
                    g.FillEllipse(Brushes.Black, x+21,y+10,8,8);

                    break;
                case type.Rabbit: 
                    g.FillEllipse(Brushes.Gray, pos);

                    g.FillEllipse(Brushes.Gray, x + 5, y - 10, 5, 20);
                    g.FillEllipse(Brushes.Gray, x + 30, y - 10, 5, 20);
                    g.FillEllipse(Brushes.Black, x + 9, y + 11, 8, 8);
                    g.FillEllipse(Brushes.Black, x + 23, y + 11, 8, 8);

                    g.DrawArc(Pens.Red,new Rectangle(x+15,y+30,10,5),0,180);
                    break;
                case type.Bear:
                    g.FillRectangle(Brushes.Brown, pos);
                    g.FillRectangle(Brushes.Yellow, x + 5, y + 5, 10, 10);
                    g.FillRectangle(Brushes.Yellow,x+25,y+5,10,10);
                    g.FillRectangle(Brushes.Red,x+5,y+25,30,10);
                    break;
                case type.Wolf:
                      pts=new Point[8];
                    

                    pts[0] = new Point(x, y);
                    pts[1] = new Point(x + 40, y  );
                    pts[2] = new Point(x + 45, y+10);
                    pts[3]=  new Point(x + 35,y+10);
                    pts[4] = new Point(x + 20, y+40);
                    pts[5] = new Point(x + 5, y + 10);
                    pts[6] = new Point(x-5, y+10);
                    pts[7] = new Point(x, y);
                  
                    g.FillPolygon(Brushes.Black, pts);

                    g.FillEllipse(Brushes.YellowGreen, x+11,y+10,8,8);
                    g.FillEllipse(Brushes.YellowGreen, x + 21, y + 10, 8, 8);

                    break; 

            }

        }

        public void Live(float dt)
        {
         

            if (!isOnGround) velY += lev.gravity * gravityK * dt;
            pos.X += velX * dt;
            pos.Y += velY * dt;

            if (pos.X > lev.Size.Width || pos.X < 0 || pos.Y > lev.Size.Height || pos.Y < 0)
            {
                life = -1;
                checkDead(lev);
            }


            if (tp == type.Bullet)
            {
                foreach (Creature j in lev.creatures)
                {
                    if (j!=this && hitTest(j.pos))
                    {
                        j.life -= bullet_damage;
                        j.checkDead(lev);

                        life = -1;
                        checkDead(lev);
                    }


                }

                foreach (GameObject j in lev.objs)
                    if (j.tp!=GameObject.type.MobStopper && hitTest(j.rect))
                    { 
                        life = -1;
                        checkDead(lev);
                    }

                return;
            }

            bool hitTop = false,hitBottom=false,hitLR=false;
            bool SuperJump = false;


            float newX=0, newY=0;
            foreach (GameObject j in lev.objs)
            {

                if (this.tp==Creature.type.Kolobok && j.isTakeAble() )
                {
                    if (hitTestSmall(j))
                    {
                        switch (j.tp)
                        { 
                            case(GameObject.type.Coin):
                                lev.Score += 10;            //Increase Score if coin is found
                                break;
                            case (GameObject.type.Drug):
                                lev.DrugEaten();
                                break;                            
                        }
                   
                        lev.objsToRemove.Add(j);
                        lev.playSound(Properties.Resources.Coin);
                    }
                    continue;
                }



                int htV = hitTestVert(j);
                if (htV != 0)
                {
                    if (htV == 1)
                    {
                        hitTop = true;
                        if (j.tp == GameObject.type.Jumper) SuperJump = true;

                        if(j.tp==GameObject.type.MovingBlock)
                            BottomObj = j;

                    }

                    else if (htV == 2)
                    {
                        hitBottom = true;
                        newY = j.rect.Bottom;
                    }

                }


                int htH = hitTestHor(j);
                if ( htH != 0)
                {
                    if (htH == 3)
                    {
                        hitLR = true;
                        newX = j.rect.Left - pos.Width;
                        //  lev.playSound(Properties.Resources.Pong);
                    }

                    else if (htH == 4)
                    {
                        hitLR = true;
                        newX = j.rect.Right;
                        //  lev.playSound(Properties.Resources.Pong);
                    }
                }

                               if (j.tp==GameObject.type.Portal && tp==type.Kolobok && (htV != 0 || htH != 0))
                {
                    lev.gameOver(true);
                }

            }


            if (hitTop)
            {
                if (isOnGround == false && tp == type.Kolobok) lev.playSound(Properties.Resources.Pong);

                isOnGround = true;
                velY = 0;

            }
            else
            {
                isOnGround = false;
                BottomObj = null;
            }

            if (SuperJump)
            {
                isOnGround = false;
                velY = -2 * maxVertVel;
                lev.playSound(Properties.Resources.Jump);
            }


            if (!hitTop && hitBottom)
            {
                velY = 0;
                pos.Y = newY;
                lev.playSound(Properties.Resources.Pong);
            }
            if (hitLR)
            {
                velX = 0;
                pos.X = newX;
            }

            if (BottomObj != null)
            {
                pos.X += BottomObj.lastMove.X;
            }
 


            if (tp == type.Kolobok)
            {
                foreach (Creature j in lev.creatures)
                    if (j.isEnemy() && hitTest(j.pos))
                    {
                        // Hittng with enemy
                        
                        life -= 10;      //Kolobok will receive damage
                        checkDead(lev);


                        //j.life = -1;    // Enemy will not receive damage
                        j.checkDead(lev);


                    }

            }

            if (tp!=type.Kolobok && isOnGround)
            {
                if(velX==0 || hitLR)
                {
                   // velX = maxHorVel * (   (float)(1 - lev.rnd.NextDouble() * 2) );
                    velX = maxHorVel * (float)(-1 + 2 * Math.Floor(2*lev.rnd.NextDouble()));

                }
            }

        }

        public void checkDead(Level lev)
        {
            if (life <= 0)
            {
                if (isEnemy()) lev.Score += scoreIncIfKilled; //increase Score if enemy is Killed
                lev.crsToRemove.Add(this);
                if (tp == type.Kolobok)
                {
                    lev.gameOver(false);
                }
            }

        }

        public bool hitTest(RectangleF rect)
        {
            float x = pos.X + pos.Width / 2;
            float y = pos.Y + pos.Height / 2;
            return (x > rect.X && x < rect.X + rect.Width && y > rect.Y && y < rect.Y + rect.Height);
        }

        public bool hitTest(PointF p)
        {
            float x = p.X;
            float y = p.Y;
            return (x > pos.X && x < pos.X + pos.Width && y > pos.Y && y < pos.Y + pos.Height);
        }

        //0 - not hit 1 - top 2-bottom 3-left 4-right
        public int hitTestVert(  GameObject obj)
        {
           if ((this.tp==type.Kolobok || this.tp==type.Bullet) && obj.tp==GameObject.type.MobStopper)return 0;

           if(pos.Right > obj.rect.Left && pos.Left < obj.rect.Right )
           {
                    if( pos.Top < obj.rect.Top && pos.Bottom+3 > obj.rect.Top)
                    {
                        pos.Y = obj.rect.Top - pos.Height;
                        return 1;
                    }
                    if (pos.Top < obj.rect.Bottom && pos.Bottom + 3 > obj.rect.Bottom) 
                    { 
                        return 2;
                    }
           }

          
            
            return 0;
        }

        public int hitTestHor(GameObject obj)
        {

            if ((this.tp == type.Kolobok || this.tp == type.Bullet) && obj.tp == GameObject.type.MobStopper) return 0;
             
            if (pos.Bottom > obj.rect.Top && pos.Top < obj.rect.Bottom)
            {
                if (pos.Left < obj.rect.Left && pos.Right > obj.rect.Left)
                {
                    return 3;
                }
                if (pos.Left < obj.rect.Right && pos.Right + 3 > obj.rect.Right)
                {
                    return 4;
                }

            }

            return 0;
        }


        public bool hitTestSmall(GameObject obj)        //For coins and drugs
        {
            int radius = 20-3; // radius of coin or drug - eps
            return Geometry.dist(this.Center(),obj.Center())<this.pos.Width/2+radius;

        }

        public PointF Center()
        {
            return new PointF(pos.X + pos.Width / 2, pos.Y + pos.Height / 2);

        }

        public bool isEnemy()
        {
            return (tp == type.Fox || tp == type.Rabbit || tp == type.Bear || tp == type.Wolf);
        }

        
        public override string ToString()
        {
            switch (tp)
            { 
                case type.Kolobok:
                    return String.Format("10 {0} {1}",pos.X + KolobokRadius, pos.Y + KolobokRadius);                 
                case type.Fox:
                    return String.Format("11 {0} {1}", pos.X + 20, pos.Y + 20);
                case type.Rabbit:
                    return String.Format("12 {0} {1}", pos.X + 20, pos.Y + 20);
                case type.Bear:
                    return String.Format("13 {0} {1}", pos.X + 20, pos.Y + 20); 
                case type.Wolf:
                    return String.Format("14 {0} {1}", pos.X + 20, pos.Y + 20);
                case type.Bullet:
                    return "undefined";           
            
            }
            return "undefined";
        }
    }


}
