using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        double calcResult = 0;
        string operation = "";
        bool operation_Pressed = false;
        bool multioperand = false;
        int i;
        public Form1()
        {
            InitializeComponent();

        }
     
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
            if (result.Text == "0")
            {
                result.Text = "";
            }

            if ((b.Text == ".") && result.Text.Contains("."))
            {
                SystemSounds.Beep.Play();
            }
            else
            {
                result.Text = result.Text + b.Text;
            }
            if (result.Text == ".")
            {
                result.Text = "0.";
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            String kp = e.KeyChar.ToString();
            switch(kp)
            {
                case "1":
                    {
                        button1.PerformClick();
                        break;
                    }
                case "2":
                    {
                        button2.PerformClick();
                        break;
                    }
                case "3":
                    {
                        button3.PerformClick();
                        break;
                    }
                case "4":
                    {
                        button4.PerformClick();
                        break;
                    }
                case "5":
                    {
                        button5.PerformClick();
                        break;
                    }
                case "6":
                    {
                        button6.PerformClick();
                        break;
                    }
                case "7":
                    {
                        button7.PerformClick();
                        break;
                    }
                case "8":
                    {
                        button8.PerformClick();
                        break;
                    }
                case "9":
                    {
                        button9.PerformClick();
                        break;
                    }
                case "0":
                    {
                        button0.PerformClick();
                        break;
                    }                
                case "+":
                    {
                        buttonplus.PerformClick();
                        break;
                    }
                case "-":
                    {
                        buttonminus.PerformClick();
                        break;
                    }
                case "*":
                    {
                        buttontimes.PerformClick();
                        break;
                    }
                case "/":
                    {
                        buttondiv.PerformClick();
                        break;
                    }
                case "=":
                    {
                        buttonEqual.PerformClick();
                        break;
                    }
                case ".":
                    {
                        buttondecimal.PerformClick();
                        break;
                    }
                case "C":
                    {
                        buttonC.PerformClick();
                        break;
                    }                                            
                case "E":
                    {
                        buttonCE.PerformClick();
                        break;
                    }
                default:
                    {
                        SystemSounds.Beep.Play();
                        break;
                    }
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void oper_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (calcResult != 0)
            {
                equation.Text = equation.Text + " " + result.Text + " " + b.Text;
                buttonEqual.PerformClick();
                calcResult = Double.Parse(result.Text);
                operation = b.Text;
                multioperand = true;
            }
            else
            {
                calcResult = Double.Parse(result.Text);
                equation.Text = equation.Text + " " + result.Text + " " + b.Text;
                operation = b.Text;
                result.Text = "0";
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Double secondoper;
            secondoper = Double.Parse(result.Text);
            switch (operation)
            { 
                case "+":
                    {
                        calcResult = calcResult + secondoper;
                        result.Text = calcResult.ToString();
                        break;
                    }
                case "-":
                    {
                        calcResult = calcResult - secondoper;
                        result.Text = calcResult.ToString();
                        break;
                    }
                case "*":
                    {
                        calcResult = calcResult * secondoper;
                        result.Text = calcResult.ToString();
                        break;
                    }
                case "/":
                    {
                        calcResult = calcResult / secondoper;
                        result.Text = calcResult.ToString();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            this.result.Text = "0";
            this.equation.Text = "";
            this.operation = string.Empty;
        }
    }
}
