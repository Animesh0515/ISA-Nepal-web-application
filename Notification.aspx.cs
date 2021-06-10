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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindData();
            }

        }
        protected void BindData()
        {
            List<NotificationModel> notificationslst = new List<NotificationModel>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select notification from usernotification";
            try
            {
                conn.Open();
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    NotificationModel model = new NotificationModel();
                    model.Notification = data["notification"].ToString();
                    notificationslst.Add(model);
                }
                dgvnotification.DataSource = notificationslst;
                dgvnotification.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert into  notification (Date) values('" + datenow + "')";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int Id = getId(datenow);

                string query = "insert into usernotification(user_Id,notification_id,notification) values('" + Global.ID + "','" + Id + "','" + txtnotification.Text + "')";
                MySqlCommand cmmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "notifimsg()", true);
                    this.BindData();
                    txtnotification.Text = "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public int getId(string date)
        {
            int ID = 0;
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select Notification_Id from  notification where Date='" + date + "'";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = int.Parse(rdr["Notification_Id"].ToString());
                }
                conn.Close();
                return ID;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ID;
        }
    }
}