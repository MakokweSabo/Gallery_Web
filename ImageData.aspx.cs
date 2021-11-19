using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Gallery_Web
{
    public partial class ImageData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Label13.Visible = false;
            Label2.Visible = false;


        }


        public void AddToDatabase()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            
            SqlCommand AddData = new SqlCommand("INSERT INTO IMAGE VALUES(@UserName,@Album_ID,@ImagePath,@ImageName,@ImageSize,@DateUploaded)", con);
            AddData.Parameters.AddWithValue("@UserName", Session["User"].ToString());
            AddData.Parameters.AddWithValue("@Album_ID",DBNull.Value);
            AddData.Parameters.AddWithValue("@ImagePath", "~/Image/"+FileUpload1.FileName);
            AddData.Parameters.AddWithValue("@ImageName", FileUpload1.FileName);
            AddData.Parameters.AddWithValue("@ImageSize", (FileUpload1.Height + "+" + FileUpload1.Width).ToString());
            AddData.Parameters.AddWithValue("@DateUploaded", DateTime.Now);
            AddData.ExecuteNonQuery();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label13.Visible = true;
            if (FileUpload1.HasFile)
            {

                
                
                String FileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (FileExtension.Equals(".jpg") || FileExtension.Equals(".ico") || FileExtension.Equals(".jpeg") || FileExtension.Equals(".jpg")
                    || FileExtension.Equals(".gif") || FileExtension.Equals(".tiff") || FileExtension.Equals(".png"))
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Image/" + FileUpload1.FileName));
                    Label13.Text = "upload successful";
                    Label13.ForeColor = System.Drawing.Color.Green;
                    ImageButton1.ImageUrl = "~/Image/" + FileUpload1.FileName;
                    Label2.Visible = true;



                    AddToDatabase();

                }
                else
                {

                    Response.Write("‘UNSUPPORTED FORMAT, PLEASE UPLOAD CONTENT IN A DIFFERENT FORMAT ");


                }



            }
            else
            {

               
                Label13.Text = "PLEASE SELECT FILE TO UPLOAD!";
                Label13.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}