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
        string connectionstring = DatabaseConnectionModel.ConnectionString();
        static bool search ;
        int index;
        static UserModel userModel = new UserModel();
        static List<UserModel> userslst = new List<UserModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(! this.IsPostBack)
            {
                userslst.Clear();
                search = false;
                this.Bindgrid();
                

            }

        }
        private void Bindgrid()
        {
            int counter = 0;
           
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
                    DateTime dob = DateTime.Parse(data["DateOfBirth"].ToString());
                    users.DateofBirth = dob.ToString("yyyy-MM-dd");
                    users.Username = data["Username"].ToString();
                    users.Password = data["Password"].ToString();
                    users.Gender = data["Gender"].ToString();
                    users.Age = int.Parse(data["Age"].ToString());
                    users.Address = data["Address"].ToString();
                    DateTime jd= DateTime.Parse(data["JoinedDate"].ToString());
                    users.JoinedDate = jd.ToString("yyyy -MM-dd");
                    users.RowIndex = counter++;
                   userslst.Add(users);
                    
                }
                conn.Close();
                dgvmemebers.DataSource = userslst;
                dgvmemebers.DataBind();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            if (!search)
            {

                dgvmemebers.EditIndex = e.NewEditIndex;
            }
            else
            {
                dgvmemebers.EditIndex = userModel.RowIndex;
                userslst.Clear();
            }
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
            userslst.Clear();
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
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE User_ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.Bindgrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string data = txtsearch.Text;
            List<UserModel> usrlst = new List<UserModel>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select User_Id, Role, First_Name, Last_Name,  Email, Phone_Number, DateOfBirth, Username, Password, Gender, Age, Address, JoinedDate from users where Upper(First_Name)=Upper('"+data+ "') or Upper(Last_Name)=Upper('" + data + "') or Upper(Username)=Upper('" + data + "') and Role='user'";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserModel users = new UserModel();
                    users.UserId = int.Parse(rdr["User_Id"].ToString());
                    users.Role = rdr["Role"].ToString();
                    users.FirstName = rdr["First_Name"].ToString();
                    users.LastName = rdr["Last_Name"].ToString();
                    users.Email = rdr["Email"].ToString();
                    users.PhoneNumber = int.Parse(rdr["Phone_Number"].ToString());
                    DateTime dob = DateTime.Parse(rdr["DateOfBirth"].ToString());
                    users.DateofBirth = dob.ToString("yyyy-MM-dd");
                    users.Username = rdr["Username"].ToString();
                    users.Password = rdr["Password"].ToString();
                    users.Gender = rdr["Gender"].ToString();
                    users.Age = int.Parse(rdr["Age"].ToString());
                    users.Address = rdr["Address"].ToString();
                    DateTime jd = DateTime.Parse(rdr["JoinedDate"].ToString());
                    users.JoinedDate = jd.ToString("yyyy-MM-dd");
                    index=users.RowIndex;

                    usrlst.Add(users);
                    userModel = userslst.Where(x => x.Username == users.Username).FirstOrDefault();
                }
                conn.Close();
                
                dgvmemebers.DataSource = usrlst;
                //dgvmemebers.AutoGenerateEditButton = false;
                //dgvmemebers.AutoGenerateDeleteButton = false;
                dgvmemebers.DataBind();
                search = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}