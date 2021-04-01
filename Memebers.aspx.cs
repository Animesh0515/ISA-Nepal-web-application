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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.connectionstring();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! this.IsPostBack)
            {
                this.Bindgrid();
            }

        }
        private void Bindgrid()
        {
            List<UserModel> userslst = new List<UserModel>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select User_Id, Role, First_Name, Last_Name,  Email, Phone_Number, DateOfBirth, Username, Password, Gender, Age, Address, JoinedDate from users where Role='user'";
            try
            {
                conn.Open();
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    UserModel users = new UserModel();
                    users.UserId = int.Parse(data["User_Id"].ToString());
                    users.Role = data["Role"].ToString();
                    users.FirstName = data["First_Name"].ToString();
                    users.LastName = data["Last_Name"].ToString();
                    users.Email = data["Email"].ToString();
                    users.PhoneNumber = int.Parse(data["Phone_Number"].ToString());
                    users.DateofBirth = data["DateOfBirth"].ToString();
                    users.Username = data["Username"].ToString();
                    users.Password = data["Password"].ToString();
                    users.Gender = data["Gender"].ToString();
                    users.Age = int.Parse(data["Age"].ToString());
                    users.Address = data["Address"].ToString();
                    users.JoinedDate = data["JoinedDate"].ToString();
                    userslst.Add(users);
                }
                conn.Close();
                dgvmemebers.DataSource = userslst;
                dgvmemebers.DataBind();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvmemebers.EditIndex = e.NewEditIndex;
            this.Bindgrid();
            
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            UserModel users = new UserModel();
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvmemebers.Rows[e.RowIndex];
            users.UserId = int.Parse(dgvmemebers.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvmemebers.DataKeys[e.RowIndex].Values[0]);
            users.Role = (row.Cells[2].Controls[0] as TextBox).Text;
            users.FirstName = (row.Cells[3].Controls[0] as TextBox).Text;
            users.LastName = (row.Cells[4].Controls[0] as TextBox).Text;
            users.Email = (row.Cells[5].Controls[0] as TextBox).Text;
            users.PhoneNumber = int.Parse((row.Cells[6].Controls[0] as TextBox).Text);
            users.DateofBirth = (row.Cells[7].Controls[0] as TextBox).Text;
            users.Username = (row.Cells[8].Controls[0] as TextBox).Text;
            users.Password = (row.Cells[9].Controls[0] as TextBox).Text;
            users.Gender = (row.Cells[10].Controls[0] as TextBox).Text;
            users.Age = int.Parse((row.Cells[11].Controls[0] as TextBox).Text);
            users.Address = (row.Cells[12].Controls[0] as TextBox).Text;
            users.JoinedDate = (row.Cells[13].Controls[0] as TextBox).Text;


            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("update users set Role = '" + users.Role + "',First_Name = '" + users.FirstName + "',Last_Name='" + users.LastName + "', Email='"+users.Email+ "', Phone_Number='" + users.PhoneNumber + "', DateOfBirth='" + users.DateofBirth + "', Username='" + users.Username + "', Password='" + users.Password + "', Gender='" + users.Gender + "', Age='" + users.Age + "', Address='" + users.Address + "', JoinedDate='"+users.JoinedDate+"' where User_Id = " + users.UserId))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvmemebers.EditIndex = -1;
            this.Bindgrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvmemebers.EditIndex = -1;
            this.Bindgrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvmemebers.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvmemebers.DataKeys[e.RowIndex].Values[0]);

            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Dish WHERE Dish_ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.Bindgrid();
        }



      
        
    }
}