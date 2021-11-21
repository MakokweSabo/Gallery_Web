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
            
            Label15.Visible = false;
            Label16.Visible = false;
            Label17.Visible = false;
            Button4.Visible = false;
            TextBox4.Visible = false;

            Label13.Visible = false;
            Label2.Visible = false;
            
                if (!IsPostBack)
                {
                    ShowData();
                }
                
           


        }

        public void addAlbum()
        {
            Session["User"] = "hANGSA";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            DateTime Date = DateTime.Now;
            SqlCommand Album = new SqlCommand("INSERT INTO Album VALUES(@AlbumName,@DateCreated,@Album_Creator)", con);
            Album.Parameters.AddWithValue("@AlbumName", TextBox1.Text);
            Album.Parameters.AddWithValue("@DateCreated", Date);
            Album.Parameters.AddWithValue("@Album_Creator", Session["User"].ToString());
            Album.ExecuteNonQuery();
            con.Close();




        }
       

        public void ShowData()
        {
            Session["User"] = "fthjj";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter ShowData = new SqlDataAdapter("SELECT * FROM Image WHERE UserName = '" + Session["User"].ToString() + "'", con);
            DataTable dtb1 = new DataTable();
            ShowData.Fill(dtb1);
            con.Close();

            GridView1.Visible = true;
            
        }
        public void AddToDatabase()
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand AddData = new SqlCommand("INSERT INTO IMAGE(UserName,ImagePath,ImageName,ImageSize,DateUploaded) VALUES(@UserName,@ImagePath,@ImageName,@ImageSize,@DateUploaded)", con);
            Session["User"] = "gfdfghj";
            AddData.Parameters.AddWithValue("@UserName", Session["User"].ToString());
            AddData.Parameters.AddWithValue("@ImagePath", Path.GetFullPath(FileUpload1.FileName));
            AddData.Parameters.AddWithValue("@ImageName", FileUpload1.FileName);
            AddData.Parameters.AddWithValue("@ImageSize", (FileUpload1.FileContent.Length).ToString());
            AddData.Parameters.AddWithValue("@DateUploaded", DateTime.Now);
            AddData.ExecuteNonQuery();
            if (TextBox2.Text != null )
            {
                string Alb = "SELECT count(*) FROM UserTable WHERE UserName ='" + TextBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(Alb, con);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    SqlCommand Share = new SqlCommand("INSERT INTO Sharings VALUES(@ImageName,@ShareeName)", con);
                    Share.Parameters.AddWithValue("@ImageName", FileUpload1.FileName);
                    Share.Parameters.AddWithValue("@ShareeName", TextBox2.Text);
                    Share.ExecuteNonQuery();

                }
                else
                {
                    
                    Label11.Text = "USERNAME " + TextBox2.Text + " DOES NOT EXIST,ENTER EXISTING USERNAME!";
                }
                 

            }
            
            
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
                    try
                    {
                        if (TextBox3.Text == null)
                        {

                            FileUpload1.SaveAs(Server.MapPath("~/Image/" + FileUpload1.FileName));
                            Label13.Text = "UPLOAD SUCCESSFUL!!";
                            Label13.ForeColor = System.Drawing.Color.Green;
                            ImageButton1.ImageUrl = "~/Image/" + FileUpload1.FileName;
                            Label2.Visible = true;
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            con.Open();
                            string Alb = "SELECT count(*) FROM Album WHERE AlbumName ='" + TextBox3.Text + "'";
                            SqlCommand cmd = new SqlCommand(Alb, con);
                            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            con.Close();
                            if (temp == 1)
                            {
                                FileUpload1.SaveAs(Server.MapPath("~/Image/" + TextBox3.Text + "/" + FileUpload1.FileName));
                                Label13.Text = "UPLOAD SUCCESSFUL!!";
                                Label13.ForeColor = System.Drawing.Color.Green;
                                ImageButton1.ImageUrl = "~/Image/" + TextBox3.Text + "/" + FileUpload1.FileName;
                                Label2.Visible = true;
                                GridView1.Visible = true;
                            }
                            else
                            {
                                Label4.Text = " ALBUM " + TextBox3.Text + " DOES NOT EXIST,ENTER EXISTING ALBUM";
                                Label4.ForeColor = System.Drawing.Color.Red;
                            }
                            
                        }
                        AddToDatabase();
                        ShowData();


                    }
                    catch(Exception)
                    {
                        Label13.Text = "ERROR WHILE UPLOADING!!,TRY AGAIN";
                        Label13.ForeColor = System.Drawing.Color.DarkRed;
                    }


                    






                }
                else
                {

                    Response.Write("‘UNSUPPORTED FORMAT, PLEASE UPLOAD CONTENT IN A DIFFERENT FORMAT!! ");


                }

               

            }
            else
            {

               
                Label13.Text = "PLEASE SELECT FILE TO UPLOAD!";
                Label13.ForeColor = System.Drawing.Color.Red;
            }
           
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == null)
            {
                Response.Write("PLEASE ENTER ALBUM NAME BEFORE CREATING");
                TextBox1.Focus();
                TextBox1.BorderColor = System.Drawing.Color.Red;
                
            }
            else
            {

                String firstFolder = Server.MapPath("~/Image/");
                string subFolder = Path.Combine(firstFolder, TextBox1.Text);
                Directory.CreateDirectory(subFolder);

                Label14.Text = "ALBUM CREATED SUCCESSFULLY!!";
                Label14.ForeColor = System.Drawing.Color.Green;
                addAlbum();


            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["User"] = "gdtdtd";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                 con.Open();
                SqlDataAdapter ShowData = new SqlDataAdapter("SELECT * FROM Album WHERE Album_Creator ='" + Session["User"].ToString()+"'",  con);
                DataTable dtb2 = new DataTable();
                ShowData.Fill(dtb2);
            Label15.Visible = true;
            Label16.Visible = true;
            Label17.Visible = true;
            Button4.Visible = true;
            TextBox4.Visible = true;
            GridView1.Visible = false;
                con.Close();


            GridView2.Visible = true;   
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if(TextBox4.Text == null)
            {
                Label17.Text = "PLEASE ENTER ALBUM NAME TO DELETE";
                TextBox4.Focus();

            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
               System.IO.Directory.Delete(Server.MapPath("~/Image/" + TextBox4.Text + "/" + FileUpload1.FileName), true);
                
                SqlCommand ShowData = new SqlCommand("DELETE  FROM Album WHERE AlbumName = '" + TextBox4.Text + "'", con);
                ShowData.ExecuteNonQuery();


            }
        }
    }
}