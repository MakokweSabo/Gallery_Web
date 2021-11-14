using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;




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
            RequiredFieldValidator1.Enabled = false;
            Label5.Visible = true;
            TextBox3.Visible = true;
            Button1.Visible = false;
            Button2.Visible = true;
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
            
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
                if(pass == Encryptdata(TextBox2.Text))
                {
                    Label7.Text = "PASSWORD CORRECT!!";
                    Label7.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Label7.Text = "INCORRECT PASSWORD!!";
                    Label7.ForeColor = System.Drawing.Color.Red;
                    RequiredFieldValidator2.Enabled = false;
                    
                    

                }
            }
            else
            {
                Label7.Text ="INCORRECT LOG-IN DETAILS!,ENTER CORRECT CREDENTIALS OR REGISTER IF YOU ARE A NEW USER!!";
                Label7.ForeColor = System.Drawing.Color.Red;
                RequiredFieldValidator2.Enabled = false;

            }
           
                  
                
          


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator2.Enabled = true;
            CompareValidator2.Enabled = true;
            Label5.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string User = "SELECT count(*) FROM UserTable WHERE UserName ='" + TextBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(User, con);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                Label7.Text = "USER NAME ALREADY TAKEN!!,CHOOSE ANOTHER ONE";
                Label7.ForeColor = System.Drawing.Color.Red;
                
                
            }
            else
            {
                con.Open();
                string passW = "SELECT Password FROM UserTable";
                SqlCommand com = new SqlCommand(passW, con);
                string tempo = com.ExecuteScalar().ToString();
                if (tempo == TextBox2.Text)
                {
                    Label7.Text = "WEAK PASSWORD!!";
                    Label7.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Label7.Text = "REGISTRATION SUCCESSFUL!!.NOW LOG-IN";
                    Label7.ForeColor = System.Drawing.Color.Green;

                }
                

          
                 Button1.Visible = true;
                 Button2.Visible = false;
                TextBox3.Visible = false;
                Label5.Visible = false;

                
                SqlCommand AddUser = new SqlCommand("INSERT INTO UserTable VALUES(@UserName,@Password)",con);
                AddUser.Parameters.AddWithValue("@UserName", TextBox1.Text);
                AddUser.Parameters.AddWithValue("@Password", Encryptdata(TextBox2.Text));
                AddUser.ExecuteNonQuery();

                con.Close();



            }

            


        }
               
            
        
    }
}