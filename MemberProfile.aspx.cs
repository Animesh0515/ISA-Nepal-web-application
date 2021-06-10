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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string connectionstring = DatabaseConnectionModel.ConnectionString();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = int.Parse(Request.QueryString["UserID"]);

            if (!this.IsPostBack)
            {
                GetProfile();
            }
        }
        protected void GetProfile()
        {
            txtfirstname.Enabled = false;
            txtlastname.Enabled = false;
            txtemail.Enabled = false;
            txtphoneno.Enabled = false;
            txtdob.Enabled = false;
            txtusername.Enabled = false;
            txtgender.Enabled = false;
            txtage.Enabled = false;
            txtjoineddate.Enabled = false;
            addresstxt.Enabled = false;
            btncancel.Visible = false;
            btnedit.Visible = true;
            btnsaved.Visible = false;

            MySqlConnection conn = new MySqlConnection(connectionstring);
            string query = "Select * from users where User_Id='" + UserID + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtfirstname.Text = rdr["First_Name"].ToString();
                txtlastname.Text = rdr["Last_Name"].ToString();
                Label1.Text = txtfirstname.Text + " " + txtlastname.Text;
                txtemail.Text = rdr["Email"].ToString();
                txtphoneno.Text = rdr["Phone_Number"].ToString();
                DateTime dob = Convert.ToDateTime(rdr["DateOfBirth"].ToString());
                txtdob.Text = dob.ToString("yyyy-MM-dd");
                txtusername.Text = rdr["Username"].ToString();
                txtgender.Text = rdr["Gender"].ToString();
                txtage.Text = rdr["Age"].ToString();
                DateTime jd = Convert.ToDateTime(rdr["JoinedDate"].ToString());
                txtjoineddate.Text = jd.ToString("yyyy-MM-dd");
                addresstxt.Text = rdr["Address"].ToString();
                byte[] bytes = Convert.FromBase64String(rdr["ImageUrl"].ToString());
                imgadm.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                




            }
            conn.Close();
        }
      

        protected void btnedit_Click(object sender, EventArgs e)
        {
            txtfirstname.Enabled = true;
            txtlastname.Enabled = true;
            txtemail.Enabled = true;
            txtphoneno.Enabled = true;
            txtdob.Enabled = true;
            txtusername.Enabled = true;
            txtgender.Enabled = true;
            txtage.Enabled = true;
            txtjoineddate.Enabled = true;
            addresstxt.Enabled = true;
            btncancel.Visible = true;
            btnsaved.Visible = true;
            btnedit.Visible = false;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtfirstname.Enabled = false;
            txtlastname.Enabled = false;
            txtemail.Enabled = false;
            txtphoneno.Enabled = false;
            txtdob.Enabled = false;
            txtusername.Enabled = false;
            txtgender.Enabled = false;
            txtage.Enabled = false;
            txtjoineddate.Enabled = false;
            addresstxt.Enabled = false;
            btncancel.Visible = false;
            btnsaved.Visible = false;
            btnedit.Visible = true;
        }

        protected void btnsaved_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(connectionstring);
            string query;
           
                query = "update users set First_Name='" + txtfirstname.Text + "', Last_Name='" + txtlastname.Text + "', Email='" + txtemail.Text + "',Phone_Number='" + txtphoneno.Text + "',DateOfBirth='" + txtdob.Text + "', Username='" + txtusername.Text + "',Gender='" + txtgender.Text + "',Age='" + txtage.Text + "',Address='" + addresstxt.Text + "',JoinedDate='" + txtjoineddate.Text + "'where User_Id='" + UserID + "'";

            
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "successmsg()", true);

                this.GetProfile();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

       
    }
}