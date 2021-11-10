using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


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

             
           
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string User = "SELECT count(*) FROM UserTable WHERE UserName ='" + TextBox1.Text + "'";
               SqlCommand cmd = new SqlCommand(User,con);
               int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
               con.Close();
            if(temp ==1)
            {
                con.Open();
                string password = "SELECT Password FROM UserTable WHERE UserName = '" + TextBox1.Text + "'";
                SqlCommand Passcmd = new SqlCommand(password, con);
                string pass = Passcmd.ExecuteScalar().ToString().Replace(" ", "");
                if(pass == TextBox2.Text)
                {
                    Response.Write("PASSWORD CORRECT!!");
                }
                else
                {
                    Response.Write("PASSWORD INCORRECT");
                    //Label7.Text = "INCORRECT LOG-IN DETAILS!,ENTER CORRECT CREDENTIALS OR REGISTER IF YOU ARE A NEW USER";

                }
            }
            else
            {
                Response.Write("INCORRECT LOG-IN DETAILS!,ENTER CORRECT CREDENTIALS OR REGISTER IF YOU ARE A NEW USER!!");
                

            }
           
                  
                
          


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