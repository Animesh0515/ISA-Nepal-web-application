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
            cmd.CommandText = "Select us.User_Id, CONCAT(us.First_name, us.last_name) as Name, cb.Booked_Date, cb.Booked_for, cb.Time, cv.Venue from users us left join courtbookingvenue cv on us.user_id=cv.user_id left join courtbooking cb on cb.court_booking_id=cv.court_booking_id where us.Role='user'";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    CourtBookingModel courtBooking = new CourtBookingModel();
                    courtBooking.UserID = int.Parse(rdr["User_Id"].ToString());
                    courtBooking.Name = rdr["Name"].ToString();
                    courtBooking.BookedDate =DateTime.Parse( rdr["Booked_Date"].ToString());
                    courtBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString());
                    courtBooking.Time = rdr["Time"].ToString();
                    courtBooking.Venue = rdr["venue"].ToString();
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
            List<TrainingBookingModel> trainingBookinglst = new List<TrainingBookingModel>();
            MySqlConnection conn = new MySqlConnection(connectiostring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select us.User_Id, CONCAT(us.First_name, us.last_name) as Name, tb.Booked_Date, tb.Booked_for, tb.Time, tv.Venue from users us left join trainingbookingvenue tv on us.user_id=tv.user_id left join trainingbooking tb on tb.training_booking_id=tv.training_booking_id where us.Role='user'; ";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TrainingBookingModel trainingBooking = new TrainingBookingModel();
                    
                    trainingBooking.UserID = int.Parse(rdr["User_Id"].ToString());
                    trainingBooking.Name = rdr["Name"].ToString();
                    trainingBooking.BookedDate = DateTime.Parse(rdr["Booked_Date"].ToString());
                    trainingBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString());
                    trainingBooking.Time = rdr["Time"].ToString();
                    trainingBooking.Venue = rdr["venue"].ToString();
                    trainingBookinglst.Add(trainingBooking);
                }
                dgvtrainingbooking.DataSource = trainingBookinglst;
                dgvtrainingbooking.DataBind();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }

        

       
    }
}