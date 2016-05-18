using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace KolobokGame
{
    public partial class Form1 : Form
    {

        int level_num;
        int level_count;
        int tracks_count ;
        
        Level lev;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (TestMode) return;

            ScanLevels();
            ScanMusic();
            //MessageBox.Show(level_count.ToString() + " " + tracks_count.ToString());
            StartLevel(1);     
        }


        string CheatCode = "";
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           // this.Text = e.KeyData.ToString(); ;
            string S = e.KeyData.ToString();
            if (S.Length == 1)
            {
                CheatCode += S;
               // this.Text = CheatCode;
                if (CheatCode == "SIEGHEIL") lev.design_mode = 1488;
                if (CheatCode == "HITLERKAPUT") lev.design_mode = 0;

            }
            else
            {
                CheatCode = "";
            }



            switch (e.KeyValue)
            {
                case 32:
                    lev.Action(Level.Actions.Shut, false);
                    break;
                case 37:
                    lev.Action(Level.Actions.GoLeft, false);
                    break;
                case 38:
                    lev.Action(Level.Actions.Jump, false);
                    break;
                case 39:
                    lev.Action(Level.Actions.GoRight, false);
                    break;
                case 40:
                    lev.Action(Level.Actions.Down, false);
                    break;
                case 112:
                    lev.Action(Level.Actions.Cheat, false);
                    break;
            } 

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            //MessageBox.Show(e.KeyValue.ToString());
            switch (e.KeyValue)
            {
                case 32:
                    lev.Action(Level.Actions.Shut, true);
                    break;
                case 37:
                    lev.Action(Level.Actions.GoLeft, true);
                    break;
                case 38:
                    lev.Action(Level.Actions.Jump, true);
                    break;
                case 39:
                    lev.Action(Level.Actions.GoRight, true);
                    break;
                case 40:
                    lev.Action(Level.Actions.Down, true);
                    break;
                
            } 
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            lev.Draw(ref pictureBox1);
            label2.Text = "Score: " + lev.Score.ToString();

            try
            {
                progressBar1.Value = lev.Kolobok.life;
            }
            catch  
            {
                return;
            }
            RefreshComponents();
        }

        private void timerAction_Tick(object sender, EventArgs e)
        {
            lev.Live((float)(timerAction.Interval/1000.0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LevelEditor z = new LevelEditor();
            z.Show();

        }

        private void lev_GameOver()
        {
            if (TestMode)
            {
                TestConsoleMsg("Game over. End testing.");
                this.Close();
                return;
            }
            
            MessageBox.Show("Game Over");
            Application.Exit();
        }

        private void lev_LevelComplete()
        {
            if (TestMode)
            {
                TestConsoleMsg("Level passed. End testing.");
                this.Close();
                return;
            }

            int score = lev.Score;

            if (level_num == level_count)
            {
                MessageBox.Show("You passed all levels. Your score is " + score.ToString() + ".");
                //TODO:  Adding to winners table
                Application.Exit();
            }
            else
            { 
                StartLevel(level_num+1);
                lev.Score = score;
            }

        }


        #region  "Testing"
            public bool TestMode = false;
            public void TestLevel(string FileName)
            {
                TestMode = true;
                TestConsoleMsg("Start testing level.");

                 
                this.Text = "The Kolobok Game - Testing Mode"  ;

                lev = new Level(FileName,pictureBox1.Size);
                lev.level_name = "";
                 

                TestConsoleMsg("Level loaded.");
                 
                
                lev.initGame();
                lev.GameOver += new DefaultHandler(lev_GameOver);
                lev.LevelComplete += new DefaultHandler(lev_LevelComplete);
                timerDraw.Start();
                timerAction.Start(); 
            }

            private void TestConsoleMsg(string text)
            {
                Console.WriteLine(text);
            }
        #endregion

        

        private void StartLevel(int num)
        {
            level_num = num;
            this.Text = "The Kolobok Game - Level " + num.ToString();

            lev = new Level(Application.StartupPath + "\\Levels\\level"+ num.ToString() + ".dat", pictureBox1.Size);
            lev.level_name = "Level " + num.ToString();


            Random rnd = new Random();
            int BGTrackNum = (int)(Math.Floor((double)rnd.Next(tracks_count)))+1;
            lev.BGTrack = "Track" + BGTrackNum.ToString() + ".mp3";

            lev.initGame();
            lev.GameOver += new DefaultHandler(lev_GameOver);
            lev.LevelComplete += new DefaultHandler(lev_LevelComplete);
            timerDraw.Start();
            timerAction.Start();   
        }

         

        private void ScanMusic()
        {
            int n = 1;
            while( File.Exists(Application.StartupPath+ "\\Music\\Track" + n.ToString() +".mp3")) {n++;}
            tracks_count=n-1; 
            if (tracks_count==0)
            {
                MessageBox.Show("No music!");            
            }
        }

        private void ScanLevels()
        { 
            int n = 1;
            while( File.Exists(Application.StartupPath + "\\Levels\\Level" + n.ToString() +".dat") ){n++;}
            level_count=n-1;  
            if (level_count==0)
            {
                MessageBox.Show("No levels!");    
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            lev.StopMusic();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        { 
            lev.BGPlayer.MasterVolume = 20 * trackBar1.Value;
            
        }
  

        private void RefreshComponents()
        {
            Point pos = PointToClient(Cursor.Position);
            trackBar1.Enabled=(pos.X>trackBar1.Left && pos.X<trackBar1.Right && pos.Y>trackBar1.Top && pos.Y<trackBar1.Bottom);
        
        }
         
    }
}
