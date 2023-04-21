using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabAss6
{
    public partial class CurrencyConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
                int Yuan = Convert.ToInt32(TextBox1.Text.Trim());
                double Dollars = Yuan * 6.914;
                Label3.Text = Yuan + " Yuan" + " = " + Dollars + " Dollars";
            }catch(Exception ex)
            {
                Label3.Text = "Please Enter a Valid Value.";
            }
            
        }
    }
}