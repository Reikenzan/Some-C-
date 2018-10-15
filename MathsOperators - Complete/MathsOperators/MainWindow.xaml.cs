﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathsOperators
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)addition.IsChecked)
                {
                    addValues();
                }
                else if ((bool)subtraction.IsChecked)
                {
                    subtractValues();
                }
                else if ((bool)multiplication.IsChecked)
                {
                    multiplyValues();
                }
                else if ((bool)division.IsChecked)
                {
                    divideValues();
                }
                else if ((bool)remainder.IsChecked)
                {
                    remainderValues();
                }
                else
                {
                    throw new InvalidOperationException("No operator selected");
                }
            }
            catch (FormatException fEx)
            {
                result.Text = fEx.Message;
            }
            catch (OverflowException oEx)
            {
                result.Text = oEx.Message;
            }
            catch (InvalidOperationException ioEx)
            {
                result.Text = ioEx.Message;
            }
            catch (Exception ex)
            {
                result.Text = ex.Message;
            }
        }

        private void addValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;

            outcome = lhs + rhs;
            expression.Text = lhsOperand.Text + " + " + rhsOperand.Text;
            result.Text = outcome.ToString();
        }

        private void subtractValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
 
            outcome = lhs - rhs;
            expression.Text = lhsOperand.Text + " - " + rhsOperand.Text;
            result.Text = outcome.ToString();
        }

        private void multiplyValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
 
            outcome = checked(lhs * rhs);
            expression.Text = lhsOperand.Text + " * " + rhsOperand.Text;
            result.Text = outcome.ToString();
        }

        private void divideValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;

            outcome = lhs / rhs;
            expression.Text = lhsOperand.Text + " / " + rhsOperand.Text;
            result.Text = outcome.ToString();
        }

        private void remainderValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
 
            outcome = lhs % rhs;
            expression.Text = lhsOperand.Text + " % " + rhsOperand.Text;
            result.Text = outcome.ToString();
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lhsOperand_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (txtreset)
            {
                txtreset = false;
            }
            else
            {
                try
                {
                    lhs = int.Parse(lhsOperand.Text);
                }
                catch (FormatException fEx)
                {
                    txtreset = true;
                    MessageBox.Show(fEx.Message + " " + lhsOperand.Text, "Try Again");
                    lhsOperand.Text = "";
                }
            }*/
        }

        private void rhsOperand_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           /* if (txtreset)
            {
                txtreset = false;
            }
            else
            {
                try
                {
                    rhs = int.Parse(rhsOperand.Text);
                }
                catch (FormatException fEx)
                {
                    txtreset = true;
                    MessageBox.Show(fEx.Message + " " + rhsOperand.Text, "Try Again");
                    lhsOperand.Text = "";
                }
            }*/
        }

        private void rhsOperand_GotFocus(object sender, RoutedEventArgs e)
        {
            lhsOperand.Background = Brushes.Gray;
            result.Text = "Please enter left operand";
        }

        private void lhsOperand_LostFocus(object sender, RoutedEventArgs e)
        {
            lhsOperand.Background = Brushes.Red;
        }

    }
}
