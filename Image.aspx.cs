using AdminPortal.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPortal
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();
        int ImageId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageId = int.Parse(Request.QueryString["ID"]);
            loadImage();

        }

        public void loadImage()
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from gallery where Media_ID='" + ImageId + "'";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    if (result["Media_Type"].ToString() == "Image")
                    {
                        Image imageButton = new Image();
                        byte[] bytes = Convert.FromBase64String(result["Media_Url"].ToString());
                        imageButton.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                        imageButton.ID = result["Media_ID"].ToString();
                        imageButton.Width = Unit.Pixel(420);
                        imageButton.Height = Unit.Pixel(250);
                        imageButton.Style.Add("padding", "5px");

                        //imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                        pnlImage.Controls.Add(imageButton);
                    }
                }

                conn.Close();


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from gallery where Media_ID='" + ImageId + "'";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                
                Response.Redirect("ISAGallery.aspx");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}