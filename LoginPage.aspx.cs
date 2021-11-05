using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gallery_Web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            TextBox3.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            Button2.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
            Label5.Visible = true;
            TextBox3.Visible = true;
            Button1.Visible = false;
            Button2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CompareValidator2.Enabled = true;
            Label5.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;
        }
    }
}