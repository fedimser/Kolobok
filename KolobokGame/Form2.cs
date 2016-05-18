using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KolobokGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Help!");
        }

        //private void ExportEnemies()
        //{
           
        //    Creature z = new Creature(Creature.type.Fox, new PointF(50,50),null);
        //    var bmp = new Bitmap(400, 100);
        //    var g = Graphics.FromImage(bmp);
        //    g.Clear(Color.White);
        //    z.Draw(ref g);


        //    z = new Creature(Creature.type.Rabbit, new PointF(150, 50),null);
        //    z.Draw(ref g);
        //    z = new Creature(Creature.type.Wolf, new PointF(250, 50),null);
        //    z.Draw(ref g);
        //    z = new Creature(Creature.type.Bear, new PointF(350, 50),null);
        //    z.Draw(ref g);
             
        //    bmp.Save(Application.StartupPath + "/Enemies.jpg");

        //}

        private void button5_Click(object sender, EventArgs e)
        {
            LevelEditor w = new LevelEditor();
            w.ShowDialog();
        }
    }
}
