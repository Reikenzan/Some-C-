using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxGame
{
    public partial class Form1 : Form
    {
        //components for game
        private Rectangle Player = new Rectangle(350,0,50,50);
        private Rectangle Goal = new Rectangle(350, 650, 50, 50);
        private Rectangle Enemy1 = new Rectangle(0, 125, 75, 75); //(0, 150, 75,75)
        private Rectangle Enemy2 = new Rectangle(375, 250, 75, 75); //(375, 350, 75, 75)
        private Rectangle Block1 = new Rectangle(350, 225, 100, 10); //(350, 320, 100, 10)
        private Rectangle Enemy3 = new Rectangle(0, 375, 75, 75);
        private Rectangle Enemy4 = new Rectangle(375, 500, 75, 75);
        private Rectangle Block2 = new Rectangle(100, 350, 100, 10);
        private Rectangle Block3 = new Rectangle(575, 475, 100, 10);
        private int jumpInterval;
        private int jumpInterval2;       
        private int timerInterval;

        //DateTime sTime;////
        //timespan object for counter
        TimeSpan timeElapsed = new TimeSpan();
        public int jumpinterval;

        public Form1()
        {
            InitializeComponent();
            //Sets to max screen
            this.MaximumSize = new Size(750,750);
            this.MinimumSize = new Size(750, 750);

            //NewGame();//
        }
       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics;

            System.Drawing.SolidBrush mybrushplayer = new System.Drawing.SolidBrush(System.Drawing.Color.Gold);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrushplayer, Player);
            mybrushplayer.Dispose();

            System.Drawing.SolidBrush mybrushgoal = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrushgoal, Goal);
            mybrushgoal.Dispose();

            System.Drawing.SolidBrush mybrushenemy1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrushenemy1, Enemy1);
            mybrushenemy1.Dispose();

            System.Drawing.SolidBrush mybrushenemy2 = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrushenemy2, Enemy2);
            mybrushenemy2.Dispose();

             System.Drawing.SolidBrush mybrushblock1 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
             formGraphics = this.CreateGraphics();
             formGraphics.FillRectangle(mybrushblock1, Block1);
             mybrushblock1.Dispose();
             //-------------------------
             System.Drawing.SolidBrush mybrushenemy3 = new System.Drawing.SolidBrush(System.Drawing.Color.Coral);
             formGraphics = this.CreateGraphics();
             formGraphics.FillRectangle(mybrushenemy3, Enemy3);
             mybrushenemy3.Dispose();

             System.Drawing.SolidBrush mybrushenemy4 = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
             formGraphics = this.CreateGraphics();
             formGraphics.FillRectangle(mybrushenemy4, Enemy4);
             mybrushenemy4.Dispose();

             System.Drawing.SolidBrush mybrushblock2 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
             formGraphics = this.CreateGraphics();
             formGraphics.FillRectangle(mybrushblock2, Block2);
             mybrushblock2.Dispose();

             System.Drawing.SolidBrush mybrushblock3 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
             formGraphics = this.CreateGraphics();
             formGraphics.FillRectangle(mybrushblock3, Block3);
             mybrushblock3.Dispose();
            //**********************************************************/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int PlayerX = Player.X;
            int PlayerY = Player.Y;

            switch (e.KeyData)
            {
                case Keys.Up: //moves Up
                    Player.Location = new Point(PlayerX += 0, PlayerY -=20);
                    break;
                case Keys.Down: //moves Down
                    Player.Location = new Point(PlayerX += 0, PlayerY +=20);
                    break;
                case Keys.Left: //moves Left
                    Player.Location = new Point(PlayerX -= 20, PlayerY += 0);
                    break;
                case Keys.Right: //moves Right
                    Player.Location = new Point(PlayerX += 20, PlayerY += 0);
                    break;
            }
            //Keep player on screen
            if(Player.Location.X <0)
            {
                Player.Location = new Point(PlayerX +=20, PlayerY +=0);
            }
            if (Player.Location.X > 700)
            {
                Player.Location = new Point(PlayerX -= 20, PlayerY += 0);
            }
            if (Player.Location.Y < 0)
            {
                Player.Location = new Point(PlayerX += 0, PlayerY += 20);
            }
            if (Player.Location.Y < 650)
            {
                Player.Location = new Point(PlayerX += 0, PlayerY -= 0);
            }
            this.Refresh();

        }

        public void HitDetect()
        {
            if(Goal.IntersectsWith(Player))
            {
                timer1.Stop();
                MessageBox.Show("You Win!");
                CheckPlayAgain();
            }
            if ((Enemy1.IntersectsWith(Player)) || (Enemy2.IntersectsWith(Player)) || (Enemy3.IntersectsWith(Player)) || (Enemy4.IntersectsWith(Player) || (Block1.IntersectsWith(Player)) || (Block2.IntersectsWith(Player)) || (Block3.IntersectsWith(Player))))
            {
                timer1.Stop();
                MessageBox.Show("You Lose!");
                CheckPlayAgain();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HitDetect();

            int ex1 = Enemy1.Location.X;
            int ey1 = Enemy1.Location.Y;
            if(ex1 > 700)
            {
                Enemy1.Location = new Point(ex1 = 0, ey1 = 125);
            }
            Enemy1.Location = new Point(ex1 += jumpInterval, ey1 += 0);

            int ex2 = Enemy2.Location.X;
            int ey2 = Enemy2.Location.Y;
            if (ex2 < 0)
            {
                Enemy2.Location = new Point(ex2 = 575, ey2 += 0); //(ex2 = 675, ey2 += 0)
            }
            Enemy2.Location = new Point(ex2 -= jumpInterval, ey2 += 0);
            //**********************************************************
            int ex3 = Enemy3.Location.X;
            int ey3 = Enemy3.Location.Y;
            if (ex3 > 700)
            {
                Enemy3.Location = new Point(ex3 = 0, ey3 = 375);
            }
            Enemy3.Location = new Point(ex3 += jumpInterval2, ey3 += 0);

            int ex4 = Enemy4.Location.X;
            int ey4 = Enemy4.Location.Y;
            if (ex4 < 0)
            {
                Enemy4.Location = new Point(ex4 = 675, ey2 += 0);
            }
            Enemy4.Location = new Point(ex4 -= jumpInterval2, ey4 += 0);

            //**********************************************************/
            this.Refresh();

      
           // this.Text = (DateTime.Now.Subtract(sTime)).ToString(@"mm\:ss");//
     
        }

        //**********************************************************
        private void CheckPlayAgain() //Ask if want to play again
        {
            DialogResult result = MessageBox.Show("You did it in "+ timeElapsed.ToString(@"mm\:ss") + "\n Play Again?", "Do you want to play again?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                //resets game
                timeElapsed = new TimeSpan();
                lbl_timer.Text = "Time: " + timeElapsed.ToString(@"mm\:ss");
                int PlayerX = Player.Location.X;
                int PlayerY = Player.Location.Y;
                Player.Location = new Point(PlayerX = 350, PlayerY = 0);
                timer2.Enabled = true;
                timer1.Enabled = true;
            }
            else
            //closes game
            {
                this.Close();
            }

            /* if (MessageBox.Show("You did ti in " +this.Text+ " Play Again?", "Play Again", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
             {
                 NewGame();
             }
             else
             {
                 Close();
             }*/
        }

       /* private void NewGame() //Ask if want to play again
        {
           // sTime = DateTime.Now;
            Player.Location = new Point(350, 0);
            timer1.Start();
        }*/

        //**********************************************************/

        private void Form1_Load(object sender, EventArgs e)
        {
            jumpInterval = 10;
            jumpInterval2 = 15;            
            timerInterval = 25;
            timer1.Interval = timerInterval;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timeElapsed = timeElapsed + new TimeSpan(0, 0, 1);
                lbl_timer.Text = "Time: " + timeElapsed.ToString(@"mm\:ss");
            }
        }
    }
}
