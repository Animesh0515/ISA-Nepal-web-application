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
                this.LoadEvent();
            }
        }
        protected void LoadEvent()
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
                dgvevents.DataSource = eventlst;
                dgvevents.DataBind();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
           
            dgvevents.EditIndex = e.NewEditIndex;
            this.LoadEvent();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CalendarModel model = new CalendarModel();
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvevents.Rows[e.RowIndex];
            model.ID = int.Parse(dgvevents.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvevents.DataKeys[e.RowIndex].Values[0]);
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

            dgvevents.EditIndex = -1;
            this.LoadEvent();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            //dgvevents.EditIndex = -1;
            //userslst.Clear();
            //this.Bindgrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvevents.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int ID = Convert.ToInt32(dgvevents.DataKeys[e.RowIndex].Values[0]);

            //using (MySqlConnection con = new MySqlConnection(connectionstring))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE User_ID =" + ID))
            //    {

            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            //this.Bindgrid();
        }

    }
}