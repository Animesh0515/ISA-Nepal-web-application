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
    public partial class WebForm6 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(! this.IsPostBack)
            {
                this.LoadCalendarEvent();
                this.LoadBookingEvents();
            }
        }
        protected void LoadCalendarEvent()
        {
            List<CalendarModel> eventlst = new List<CalendarModel>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from calendar";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    CalendarModel calendar = new CalendarModel();
                    calendar.ID = int.Parse(result["Calendar_Id"].ToString());
                    calendar.Day = result["Day"].ToString();
                    calendar.Time = result["Time"].ToString();
                    calendar.Venue = result["Venue"].ToString();
                    eventlst.Add(calendar);
                }

                conn.Close();
                dgvCalendarevents.DataSource = eventlst;
                dgvCalendarevents.DataBind();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
           
            dgvCalendarevents.EditIndex = e.NewEditIndex;
            this.LoadCalendarEvent();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CalendarModel model = new CalendarModel();
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvCalendarevents.Rows[e.RowIndex];
            model.ID = int.Parse(dgvCalendarevents.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvCalendarevents.DataKeys[e.RowIndex].Values[0]);
            model.Day = (row.Cells[1].Controls[0] as TextBox).Text;
            model.Time = (row.Cells[2].Controls[0] as TextBox).Text;
            model.Venue = (row.Cells[3].Controls[0] as TextBox).Text;




            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update calendar set Day = '" + model.Day + "',Time = '" + model.Time + "',Venue='" + model.Venue + "' where Calendar_Id = " + model.ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvCalendarevents.EditIndex = -1;
            this.LoadCalendarEvent();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvCalendarevents.EditIndex = -1;
            this.LoadCalendarEvent();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvCalendarevents.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvCalendarevents.DataKeys[e.RowIndex].Values[0]);

            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM calendar WHERE Calendar_Id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.LoadCalendarEvent();
        }

        protected void btnsaved_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlCommand cmd = new MySqlCommand("Insert into calendar(Day, Time, Venue)values('" + ddlday.SelectedValue + "','" + txtTime.Text + "','" + txtVenue.Text + "')");               

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                LoadCalendarEvent();
                ddlday.ClearSelection();
                txtTime.Text = "";
                txtVenue.Text = "";


            }

        }
        protected void LoadBookingEvents()
        {
            List<CourtBookingTime> timelst = new List<CourtBookingTime>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select ID, Time from timetable";
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    CourtBookingTime courtBooking = new CourtBookingTime();
                    courtBooking.ID= int.Parse(result["ID"].ToString());
                    courtBooking.Time = result["Time"].ToString();
                    timelst.Add(courtBooking);
                    
                }

                conn.Close();
                dgvBookingevents.DataSource = timelst;
                dgvBookingevents.DataBind();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvBookingevents.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowEditing1(object sender, GridViewEditEventArgs e)
        {

            dgvBookingevents.EditIndex = e.NewEditIndex;
            this.LoadBookingEvents();

        }

        protected void OnRowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            CourtBookingTime model = new CourtBookingTime();
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvBookingevents.Rows[e.RowIndex];
            model.ID = int.Parse(dgvBookingevents.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvCalendarevents.DataKeys[e.RowIndex].Values[0]);
            model.Time = (row.Cells[2].Controls[0] as TextBox).Text;





            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update timetable set Time = '" + model.Time + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvBookingevents.EditIndex = -1;
            this.LoadBookingEvents();
        }
        protected void OnRowCancelingEdit1(object sender, EventArgs e)
        {
            dgvBookingevents.EditIndex = -1;
            this.LoadBookingEvents();
        }
        protected void OnRowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvBookingevents.DataKeys[e.RowIndex].Values[0]);

            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM timetable WHERE ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.LoadBookingEvents();
        }

        protected void btnSaveTime_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlCommand cmd = new MySqlCommand("Insert into timetable( Time, User_Id)values('" + txtbookingTime.Text + "'," + Global.ID + ")");

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadBookingEvents();
                txtbookingTime.Text = "";
                


            }
        }
    }
}