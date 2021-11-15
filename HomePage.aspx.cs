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
            Label1.Visible = false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
                {Response.Redirect("LoginPage.aspx");
                }
            catch(Exception E)
            {

                Response.Write("ERROR!!  PAGE NOT FOUND!");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ImageData.aspx");
        }
    }
}