using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KolobokGame
{
    class GameObject
    {
        public enum type
        {
            Block,
            MovingBlock,
            Portal,
            Jumper,
            Coin,
            MobStopper, 
            Drug
        }

        public type tp;

       public Rectangle rect;
       public Point p1, p2;
       public Color Color;


        //Movement
        private float anim_time;
        public float anim_cycle;
        public Point lastMove;
         

        public GameObject(type _tp)
        {
            tp = _tp;
                       
            switch (tp)
            {
                case type.Block:
                    Color = Color.Black;
                    break;
                case type.MovingBlock:
                    Color = Color.Brown;
                    p1 = new Point(0, 0);
                    p2 = new Point(0, 0);
                    anim_time = 0;
                    break;
                case type.Portal:
                    Color = Color.Green; anim_time = 0;
                    anim_cycle = 5;
                    break;
                case type.Jumper:
                    Color = Color.Red;
                    break;
                case type.Coin:
                    Color = Color.Yellow;
                    break;
                case type.Drug:
                    Color = Color.Red;
                    break;
            }
        }


        public void DrawEditMode(ref Graphics g)
        {
            switch (tp)
            {


                case (type.Block):
                    g.FillRectangle(new HatchBrush(HatchStyle.HorizontalBrick, Color.Black, Color), rect);
                    break;
                case (type.MovingBlock):
                    g.FillRectangle(new HatchBrush(HatchStyle.HorizontalBrick, Color.Black, Color), p1.X, p1.Y, rect.Width, rect.Height);
                    g.FillRectangle(new HatchBrush(HatchStyle.HorizontalBrick, Color.Black, Color), p2.X, p2.Y, rect.Width, rect.Height);
                    var pn1 = new Pen(Color.Gray);
                    pn1.DashStyle = DashStyle.DashDot;
                    g.DrawLine(pn1, p1.X, p1.Y, p2.X, p2.Y);
                    g.DrawLine(pn1, p1.X + rect.Width, p1.Y + rect.Height, p2.X + rect.Width, p2.Y + rect.Height);
                    g.DrawLine(pn1, p1.X + rect.Width, p1.Y, p2.X + rect.Width, p2.Y);
                    g.DrawLine(pn1, p1.X, p1.Y + rect.Height, p2.X, p2.Y + rect.Height);
                    break;
                case (type.Coin):
                    g.DrawEllipse(new Pen(Color.Gold, 5), rect);
                    g.FillEllipse(new SolidBrush(Color), rect);
                    break;
                case (type.MobStopper):

                    // that's non-visible object
                    g.FillRectangle(new HatchBrush(HatchStyle.Percent25,Color.Gray,Color.Transparent), rect);
                    break;
                case (type.Portal):

                    g.FillRectangle(new SolidBrush(Color), rect);
                    var pn = new Pen(Color.Blue, 5);
                    pn.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(pn, rect);
                    break;
                case (type.Drug):
                    g.FillEllipse(new HatchBrush(HatchStyle.Cross, Color.Black, Color), rect);
                    break;
                case type.Jumper:
                    var brsh = new SolidBrush(Color);
                    g.DrawRectangle(new Pen(Color), rect);
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y, rect.Width, (int)(0.2 * rect.Height)));
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y + (int)(0.4 * rect.Height), rect.Width, (int)(0.2 * rect.Height)));
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y + (int)(0.8 * rect.Height), rect.Width, (int)(0.2 * rect.Height)));



                    break;
                default:
                    g.FillRectangle(new SolidBrush(Color), rect);
                    break;

            }
        }

        public void Draw(ref Graphics g)
        {
            switch (tp)
            {
                case (type.Block): 
                case (type.MovingBlock):
                    g.FillRectangle(new HatchBrush(HatchStyle.HorizontalBrick, Color.Black, Color), rect);
                    break;
                case (type.Coin):
                    g.DrawEllipse(new Pen(Color.Gold, 5), rect);
                    g.FillEllipse(new SolidBrush(Color), rect);
                    break;
                case (type.MobStopper):

                    // Do not draw - that's non-visible object
                    //g.DrawRectangle(Pens.Black, rect);
                    break;
                case (type.Portal):
                    g.FillRectangle(new SolidBrush(Color), rect);
                    var pn = new Pen(Color.Blue, 5);
                    pn.DashStyle = DashStyle.Dash;

                    g.DrawRectangle(pn, rect);
                    break;
                case (type.Drug):
                    g.FillEllipse(new HatchBrush(HatchStyle.Cross, Color.Black, Color), rect);
                    break;
                case type.Jumper:
                    var brsh = new SolidBrush(Color);
                    g.DrawRectangle(new Pen(Color), rect);
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y, rect.Width, (int)(0.2 * rect.Height)));
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y + (int)(0.4 * rect.Height), rect.Width, (int)(0.2 * rect.Height)));
                    g.FillRectangle(brsh, new Rectangle(rect.X, rect.Y + (int)(0.8 * rect.Height), rect.Width, (int)(0.2 * rect.Height)));



                    break;
                default:
                    g.FillRectangle(new SolidBrush(Color), rect);
                    break;

            }  

        }

        public void Live(float dt)
        {
            if (tp == type.MovingBlock)
            {
                anim_time += dt;
                if (anim_time > anim_cycle) anim_time -= anim_cycle;
                float k;
                if (anim_time < anim_cycle / 2)
                    k = 2 * anim_time / anim_cycle;
                else
                    k = 2 * (anim_cycle - anim_time) / anim_cycle;
                 
                 
                Point loc=Geometry.divide(p1,p2,k);
                lastMove = new Point(-rect.Location.X + loc.X,-rect.Location .Y + loc.Y);
                rect.Location = loc;
            }

            if (tp == type.Portal)
            {
                anim_time += dt;
                if (anim_time > anim_cycle) anim_time -= anim_cycle;
                float k;
                if (anim_time < anim_cycle / 2)
                    k = 2 * anim_time / anim_cycle;
                else
                    k = 2 * (anim_cycle - anim_time) / anim_cycle;

                Color = Color.FromArgb(255,Convert.ToInt32(k*255),Convert.ToInt32((1-k)*255),0);

            }
        
        
        }


        public override string ToString()
        {
            switch (tp)
            { 
                case (type.Block):
                    return string.Format("0 {0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height);
                case (type.MovingBlock):
                    return string.Format("1 {0} {1} {2} {3} {4} {5}", p1.X, p1.Y, rect.Width, rect.Height, p2.X, p2.Y);
                case (type.Portal):
                    return string.Format("2 {0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height);
                case (type.Jumper):
                    return string.Format("3 {0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height);
                case (type.Coin):
                    return string.Format("4 {0} {1}", rect.X +20 , rect.Y+20 );
                case (type.MobStopper):
                    return string.Format("5 {0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height);
                case (type.Drug):
                    return string.Format("6 {0} {1}", rect.X+20  , rect.Y  +20);
            }
            return "undefined";
        }

        public PointF Center()
        {
            return new PointF(rect.Left+rect.Width/2,rect.Top+rect.Height/2);
        }

        public bool isTakeAble()
        {
            return (tp == type.Coin || tp == type.Drug);
        }

        public  bool hitTest(PointF p)
        {
            float x = p.X;
            float y = p.Y;
            return (x > rect.X && x < rect.X + rect.Width && y > rect.Y && y < rect.Y + rect.Height);

        }
       
    }
}
