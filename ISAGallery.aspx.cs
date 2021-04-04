using AdminPortal.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdminPortal
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        static List<string> Videottypelst = new List<string>() { ".WEBM", ".MPG", ".MP2", ".MPEG", ".MPE", ".MPV", ".OGG", ".MP4", ".M4P", ".M4V", ".AVI", ".WMV", ".MOV", ".QT", ".FLV", ".SWF", ".AVCHD" };
        string connectionstring = DatabaseConnectionModel.ConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                pnlImg.Controls.Clear();
                this.LoadImages();
                this.LoadVideos();
            }
        }

        protected void LoadImages()
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from gallery";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    if (result["Media_Type"].ToString() == "Image")
                    {
                        ImageButton imageButton = new ImageButton();
                        imageButton.ImageUrl = result["Media_Url"].ToString();
                        imageButton.ID = result["Media_ID"].ToString();
                        imageButton.Width = Unit.Pixel(300);
                        imageButton.Height = Unit.Pixel(200);
                        imageButton.Style.Add("padding", "5px");
                        imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                        //imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                        pnlImg.Controls.Add(imageButton);
                    }
                }

                conn.Close();


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            //foreach (string file in Directory.GetFiles("G:/FYP/ISA NEPAL(Admin)/AdminPortal/Gallery/Images/"))
            //{
            //    ImageButton imageButton = new ImageButton();
            //    FileInfo fi = new FileInfo(file);
            //    imageButton.ImageUrl = "Gallery/Images/" + fi.Name;
            //    imageButton.Width = Unit.Pixel(300);
            //    imageButton.Height = Unit.Pixel(200);
            //    imageButton.Style.Add("padding", "5px");
            //    imageButton.Click += ImageButton_Click;
            //    pnlImg.Controls.Add(imageButton);

            //}
        }

        protected void LoadVideos()
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from gallery";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    if (result["Media_Type"].ToString() == "Video")
                    {
                        FileInfo fi = new FileInfo(result["Media_Name"].ToString());
                        //HtmlGenericControl myDiv = new HtmlGenericControl("div");
                        //myDiv.ID = "myDiv";
                        Literal literal = new Literal();
                        literal.ID = result["Media_ID"].ToString();
                        literal.Text = "&nbsp;<Video width=300 Controls><Source src=" + result["Media_Url"].ToString() + " type=video/mp4></video> ";
                        Console.Write(literal.Text);
                        //myDiv.Style.Add ("width","300px");
                        //myDiv.Style.Add("padding", "5px");
                        //myDiv.Controls.Add(literal);
                        
                        //pnlVdo.Controls.Add(new LiteralControl("<br/>"));
                        pnlVdo.Controls.Add(literal);
                       
                    }
                }

                conn.Close();


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            
        }

        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            // Add code here
        }



        protected void btnSaveImg_Click(object sender, EventArgs e)
        {

            bool images = true;
            if (FileUploadImg.HasFile)
            {
                string filename = FileUploadImg.FileName;
                FileInfo fi = new FileInfo(filename);
                foreach (string type in Videottypelst)
                {
                    if (fi.Extension.ToUpper() == type.ToUpper())
                    {
                        images = false;
                    }
                }
                if (images)
                {
                    DateTime dt = DateTime.Now;
                    string uploaddate = dt.ToString("yyyy-MM-dd");
                    FileUploadImg.PostedFile.SaveAs("G:/FYP/ISA NEPAL(Admin)/AdminPortal/Gallery/Images/" + filename);
                    MySqlConnection conn = new MySqlConnection(connectionstring);
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into gallery (User_ID, Media_Name, Media_Type,Date, Media_Url) values('" + Global.ID + "','" + filename + "','Image','" + uploaddate + "','Gallery/Images/" + filename + "')";
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        litImg.Text = "Saved Image";
                        conn.Close();
                        //Response.Redirect("~/ISAGallery.aspx");
                        LoadImages();

                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }

                }
                else
                {
                    litImg.Text = "Only Image file is allowed!";
                    LoadImages();

                }

            }
            else
            {
                litImg.Text = "Please select the Image file.";
                //Response.Redirect("~/ISAGallery.aspx");

                LoadImages();

            }
        }

        protected void btnSaveVdo_Click(object sender, EventArgs e)
        {
            bool video = false;
            if (FileUploadVdo.HasFile)
            {
                string filename = FileUploadVdo.FileName;
                FileInfo fi = new FileInfo(filename);
                foreach (string type in Videottypelst)
                {


                    if (fi.Extension.ToUpper() == type.ToUpper())
                    {
                        video = true;
                    }
                }
                if (video)
                {
                    DateTime dt = DateTime.Now;
                    string uploaddate = dt.ToString("yyyy-MM-dd");
                    FileUploadImg.PostedFile.SaveAs("G:/FYP/ISA NEPAL(Admin)/AdminPortal/Gallery/Videos/" + filename);
                    MySqlConnection conn = new MySqlConnection(connectionstring);
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into gallery (User_ID, Media_Name, Media_Type,Date, Media_Url) values('" + Global.ID + "','" + filename + "','Video','" + uploaddate + "','Gallery/Videos/" + filename + "')";
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        litVdo.Text = "Saved video";
                        conn.Close();
                        //Response.Redirect("~/ISAGallery.aspx");
                        LoadVideos();


                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }
                }
                else
                {
                    litVdo.Text = "Only Video file is allowed!";
                    LoadVideos();
                }
            }
            else
            {
                litVdo.Text = "Please select the video file.";
                LoadVideos();


            }
        }

    }
}
