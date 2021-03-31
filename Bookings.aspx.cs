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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectiostring = DatabaseConnectionModel.ConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! this.IsPostBack)
            {
                this.BindCourtGrid();
                this.BindTrainingGrid();
            }

        }
        protected void BindCourtGrid()
        {
            List<CourtBookingModel> courtBookinglst = new List<CourtBookingModel>();
            MySqlConnection conn = new MySqlConnection(connectiostring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from  courtbooking";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    CourtBookingModel courtBooking = new CourtBookingModel();
                    courtBooking.BookedDate =DateTime.Parse( rdr["Booked_Date"].ToString());
                    courtBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString());
                    courtBooking.Time = rdr["Time"].ToString();
                    courtBookinglst.Add(courtBooking);
                }
                dgvcourtbooking.DataSource = courtBookinglst;
                dgvcourtbooking.DataBind();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            

        }
        protected void BindTrainingGrid()
        {
            List<CourtBookingModel> courtBookinglst = new List<CourtBookingModel>();
            MySqlConnection conn = new MySqlConnection(connectiostring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from  courtbooking";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CourtBookingModel courtBooking = new CourtBookingModel();
                    courtBooking.BookedDate = DateTime.Parse(rdr["Booked_Date"].ToString());
                    courtBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString());
                    courtBooking.Time = rdr["Time"].ToString();
                    courtBookinglst.Add(courtBooking);
                }
                dgvtrainingbooking.DataSource = courtBookinglst;
                dgvtrainingbooking.DataBind();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }
    }
}