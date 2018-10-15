using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalGame
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int timeLeft;
        int cordX;
        int cordY;

        private Rectangle Target = new Rectangle(10, 125, 40, 40);

        public void StartTheGame()
        {
            cordX = randomizer.Next(1, 600);
            cordY = randomizer.Next(1, 610);

            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();

            this.MaximumSize = new Size(650, 650);
            this.MinimumSize = new Size(650, 650);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            /*if ()
            {
                
                MessageBox.Show("You win!", "Congrats!");
                startButton.Enabled = true;
            }
            else */if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry! Try again!");
            }

            this.Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int ex1 = Target.Location.X;
            int ey1 = Target.Location.Y;
            if (timeLeft > 0)
            {
                Target.Location = new Point(ex1 += 10, ey1 += 100);
            }
            Target.Location = new Point(ex1 -= cordX, ey1 += cordY);

            this.Refresh();

        }

        public void HitDetect()
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheGame();
            startButton.Visible =false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics;

            System.Drawing.SolidBrush mybrushtarget = new System.Drawing.SolidBrush(System.Drawing.Color.Gold);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrushtarget, Target);
            mybrushtarget.Dispose();

        }
        
    }
}
