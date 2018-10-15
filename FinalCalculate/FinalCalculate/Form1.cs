using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCalculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Total_Click(object sender, EventArgs e)
        {          
            //Pizza Size 
            double data1 = Convert.ToDouble(Small.Text);
            double result1 = data1 * (8.95);
            double data2 = Convert.ToDouble(Medium.Text);
            double result2 = data2 * (10.95);
            double data3 = Convert.ToDouble(Large.Text);
            double result3 = data3 * (12.95);
            double totapi = result1 + result2 + result3;
            Pizzas.Text = totapi.ToString();
            //Toppings checkboxes 
            double dblPizzaPrice = 0.00;
            if (ExtraCheese.Checked)
            {
                dblPizzaPrice = dblPizzaPrice + 1.00;
            }
            if (Pepperoni.Checked)
            {
                dblPizzaPrice = dblPizzaPrice + 1.00;
            }
            if(Sausage.Checked)
            {
                dblPizzaPrice = dblPizzaPrice + 1.00;
            }
            Topings.Text = dblPizzaPrice.ToString();
                        
            //Extras
            Extras.Text = ((Convert.ToDouble(Soda.Text) * 1.00) + (Convert.ToDouble(Wings.Text) * 3.00) + (Convert.ToDouble(BreadSticks.Text) * 2.50)).ToString();
          
            /* if ((string.IsNullOrEmpty(Soda.Text)) && (string.IsNullOrEmpty(Wings.Text)) && (string.IsNullOrEmpty(BreadSticks.Text)))
             {
                 Extras.Text = ((Convert.ToDouble(Soda.Text) * 1.00) + (Convert.ToDouble(Wings.Text) * 3.00) + (Convert.ToDouble(BreadSticks.Text) * 2.50)).ToString();
             }*/

            //Total Order 
            TotalOrder.Text = (Convert.ToDouble(Pizzas.Text) + Convert.ToDouble(Topings.Text) + Convert.ToDouble(Extras.Text)).ToString();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Small.Value = 0;
            Medium.Value = 0;
            Large.Value = 0;

            ExtraCheese.Checked = false;
            Pepperoni.Checked = false;
            Sausage.Checked = false;

            Soda.Clear();
            Wings.Clear();
            BreadSticks.Clear();

            Pizzas.Clear();
            Topings.Clear();
            Extras.Clear();

            TotalOrder.Clear();
        }

    }
}
