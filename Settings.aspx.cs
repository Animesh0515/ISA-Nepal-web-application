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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkBookingStatus();
        }

        protected void checkBookingStatus()
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from mobilebookingfeature ";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                if(result.Read())
                {
                    if(result["Status"].ToString()== "E")
                    {
                        btnON.CssClass = "btn btn-success";
                        btnOFF.CssClass = "btn btn-default";
                    }
                    else if(result["Status"].ToString() == "D")
                    {
                        btnON.CssClass = "btn btn-default";
                        btnOFF.CssClass = "btn btn-success";
                    }
                }
                

                conn.Close();
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void btnON_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update mobilebookingfeature set Status = 'E'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }
            checkBookingStatus();
        }

        protected void btnOFF_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update mobilebookingfeature set Status = 'D'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }
            checkBookingStatus();
        }
    }
}