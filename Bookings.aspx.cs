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
            if (!this.IsPostBack)
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
            cmd.CommandText = "Select us.User_Id, CONCAT(us.First_name, us.last_name) as Name, cb.Court_Booking_ID, cb.Booked_Date, cb.Booked_for, cb.Time from courtbooking cb left join  users us on cb.user_id=us.user_id where us.Role='user' and us.Flag='A'";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CourtBookingModel courtBooking = new CourtBookingModel();
                    courtBooking.BookingID = int.Parse(rdr["Court_Booking_ID"].ToString());
                    courtBooking.UserID = int.Parse(rdr["User_Id"].ToString());
                    courtBooking.Name = rdr["Name"].ToString();
                    courtBooking.BookedDate = DateTime.Parse(rdr["Booked_Date"].ToString()).ToString("d MMMM yyyy");
                    courtBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString()).ToString("d MMMM yyyy");
                    courtBooking.Time = rdr["Time"].ToString();

                    courtBookinglst.Add(courtBooking);
                }
                dgvcourtbooking.DataSource = courtBookinglst;
                dgvcourtbooking.DataBind();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }


        }
        protected void BindTrainingGrid()
        {
            List<TrainingBookingModel> trainingBookinglst = new List<TrainingBookingModel>();
            MySqlConnection conn = new MySqlConnection(connectiostring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select us.User_Id, CONCAT(us.First_name, us.last_name) as Name, tb.Training_Booking_Id, tb.Booked_Date, tb.Booked_for, tb.Time, tv.Venue, tb.Joined_Date from trainingbookingvenue tv left join  users us on us.user_id=tv.user_id left join trainingbooking tb on tb.training_booking_id=tv.training_booking_id where us.Role='user' and us.Flag='A'";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TrainingBookingModel trainingBooking = new TrainingBookingModel();
                    trainingBooking.BookingID = int.Parse(rdr["Training_Booking_Id"].ToString());
                    trainingBooking.UserID = int.Parse(rdr["User_Id"].ToString());
                    trainingBooking.Name = rdr["Name"].ToString();
                    trainingBooking.BookedDate = DateTime.Parse(rdr["Booked_Date"].ToString()).ToString("d MMMM yyyy HH:mm:ss tt");
                    trainingBooking.BookedFor = DateTime.Parse(rdr["Booked_for"].ToString()).ToString("d MMMM yyyy");
                    trainingBooking.Time = rdr["Time"].ToString();
                    trainingBooking.Venue = rdr["venue"].ToString();
                    string abc = rdr["Joined_Date"].ToString();
                    if (rdr["Joined_Date"].ToString() == null || rdr["Joined_Date"].ToString() == "")
                    {
                        trainingBooking.TrainingJoinedDate = null;
                    }
                    else{
                        trainingBooking.TrainingJoinedDate = DateTime.Parse(rdr["Joined_Date"].ToString()).ToString("d MMMM yyyy");

                    }
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
        protected void OnRowDataBound0(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvcourtbooking.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting0(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvcourtbooking.DataKeys[e.RowIndex].Values[0]);

            using (MySqlConnection con = new MySqlConnection(connectiostring))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM courtbooking WHERE court_booking_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    
                }
            }
            this.BindCourtGrid();
        }

        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvtrainingbooking.EditIndex)
        //    {
        //        (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        //    }

        //}
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvtrainingbooking.DataKeys[e.RowIndex].Values[0]);

            using (MySqlConnection con = new MySqlConnection(connectiostring))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM trainingbookingvenue WHERE training_booking_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MySqlCommand cmd2 = new MySqlCommand("Delete from trainingbooking where training_booking_id=" + ID);
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindTrainingGrid();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            dgvtrainingbooking.EditIndex = e.NewEditIndex;
            this.BindTrainingGrid();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvtrainingbooking.Rows[e.RowIndex];
            int ID = int.Parse(dgvtrainingbooking.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvCalendarevents.DataKeys[e.RowIndex].Values[0]);
            string JoinedDate = DateTime.Parse((row.Cells[8].Controls[0] as TextBox).Text).ToString("yyyy-MM-dd");
            






            using (MySqlConnection con = new MySqlConnection(connectiostring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update trainingbooking set Joined_Date = '" + JoinedDate + "' where Training_booking_Id = " + ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvtrainingbooking.EditIndex = -1;
            this.BindTrainingGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvtrainingbooking.EditIndex = -1;
            this.BindTrainingGrid();
        }
        

       

        


        
}
}