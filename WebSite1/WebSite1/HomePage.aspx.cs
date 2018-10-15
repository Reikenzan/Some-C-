using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite1
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int inputTemp;
            int outputTemp;

            inputTemp = Convert.ToInt32(this.txtITemp.Text);

            if(this.baseTemp.SelectedValue == "F")
            {
                outputTemp = Convert.ToInt32((inputTemp - 32.0) * 5.0 / 9.0);
                txtOTemp.Text = outputTemp.ToString() + " C";
            }
            else
            {
                outputTemp = Convert.ToInt32((inputTemp * 9.0 / 5.0) + 32.0);
                txtOTemp.Text = outputTemp.ToString() + " F";
            }

        }
    }
}