using AdminPortal.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPortal
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();
        int VideoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoId = int.Parse(Request.QueryString["ID"]);
            loadVideo();

        }
        public void loadVideo()
        {
           
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from gallery where Media_ID='"+VideoId+"'";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    if (result["Media_Type"].ToString() == "Video")
                    {
                       
                        Literal literal = new Literal();
                        byte[] bytes = Convert.FromBase64String(result["Media_Url"].ToString());
                        string video = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                        literal.Text = "&nbsp;<Video width=420 height=250 Controls onclick='videoView(" + literal.ID + ")' style='padding:10px'><Source src=" + video + " 'type=video/mp4></video> ";


                        //myDiv.Style.Add ("width","300px");
                        //myDiv.Style.Add("padding", "5px");
                        //myDiv.Controls.Add(literal);

                        //pnlVdo.Controls.Add(new LiteralControl("<br/>"));
                        pnlVideo.Controls.Add(literal);

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
            cmd.CommandText = "Delete from gallery where Media_ID='" + VideoId + "'";
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