using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gallery_Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Visible = true;
            if(Session["User"] == null)
            {
                Label6.Visible = false;
                Label7.Visible = false;
            }
            else
            {
                Label6.Visible = true;
                Label7.Visible = true;
                Label7.Text = Session["User"].ToString();
                Label1.Visible = false;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Response.Redirect("LoginPage.aspx");
            }
            catch(Exception )
            {

                Response.Write("ERROR!!  PAGE NOT FOUND!");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if(Session["User"] == null)
                {
                    Label1.Visible = true;
                    Label1.Text = "ACCESS REQUIRED!!,PLEASE LOG IN FIRST";
                }
                else
                {
                    Response.Redirect("ImageData.aspx");
                    
                }
                
            }
            catch(Exception)
            {
                Response.Write("ERROR!! PAGE NOT FOUND!");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Label1.Visible = true;
                    Label1.Text = "ACCESS REQUIRED!!,PLEASE LOG IN FIRST";
                }
                else
                {
                    Response.Redirect("ImageData.aspx");
                    
                }

            }
            catch (Exception)
            {
                Response.Write("ERROR!! PAGE NOT FOUND!");
                
            }
        }
    }
}