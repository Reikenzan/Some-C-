using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        //addition Variables
        int addend1;
        int addend2;
        int addans;
        //Substion Variables
        int minuend;
        int substrahend;
        int subsans;
        //Multiplication Variables
        int multiplicand;
        int multiplier;
        int multians;
        //Division Variables
        int dividend;
        int divisor;
        int divans;
        //timer
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            //Addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            //Display values
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            addans = addend1 + addend2;
            sum.Value = 0;

            //Subtraction
            minuend = randomizer.Next(1, 101);
            substrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = substrahend.ToString();
            difference.Value = 0;
            subsans = minuend - substrahend;

            //Multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
            multians = multiplicand * multiplier;

            //Division
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            divans = dividend / divisor;

            //Start timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congrats!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry! Try again!");
                sum.Value = addans;
                difference.Value = subsans;
                product.Value = multians;
                quotient.Value = divans;
                startButton.Enabled = true;
            }
        }

        private bool CheckAnswer()
        {
            if ((addans == sum.Value) && 
                (subsans == difference.Value) && 
                (multians == product.Value) && 
                (divans == quotient.Value))
                return true;
            else
                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if(addans == sum.Value)
            {
                sum.Enabled = false;
                correctAdd.Visible = true;
                correctAdd.Enabled = true;
                correctAdd.Checked = true;
                correctAdd.Enabled = false;
            }
            if(sum.Enabled == false)
            {
                sum.Value = addans;
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if(subsans == difference.Value)
            {
                difference.Enabled = false;
                correctSubs.Visible = true;
                correctSubs.Enabled = true;
                correctSubs.Checked = true;
                correctSubs.Enabled = false;
            }
            if(difference.Enabled == false)
            {
                difference.Value = subsans;
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if(multians == product.Value)
            {
                product.Enabled = false;
                correctMulti.Visible = true;
                correctMulti.Enabled = true;
                correctMulti.Checked = true;
                correctMulti.Enabled = false;
            }
            if(product.Enabled == false)
            {
                product.Value = multians;
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if(divans == quotient.Value)
            {
                quotient.Enabled = false;
                correctDivide.Visible = true;
                correctDivide.Enabled = true;
                correctDivide.Checked = true;
                correctDivide.Enabled = false;
            }
            if(quotient.Enabled == false)
            {
                quotient.Value = divans;
            }
        }
    }
}