using AdminPortal.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPortal
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connectiostring = DatabaseConnectionModel.ConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! this.IsPostBack)
            {
                this.GetProfile();
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
            txtpassword.Enabled = false;
            txtgender.Enabled = false;
            txtage.Enabled = false;
            txtjoineddate.Enabled = false;
            txtaddress.Enabled = false;
            btncancel.Visible = false;

            MySqlConnection conn = new MySqlConnection(connectiostring);
            string query = "Select * from users where User_Id='" + Global.ID + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                txtfirstname.Text = rdr["First_Name"].ToString();
                txtlastname.Text = rdr["Last_Name"].ToString();
                Label1.Text = txtfirstname.Text +""+ txtlastname.Text;
                txtemail.Text = rdr["Email"].ToString();
                txtphoneno.Text = rdr["Phone_Number"].ToString();
                DateTime dob=Convert.ToDateTime(rdr["DateOfBirth"].ToString());
                txtdob.Text = dob.ToString("yyyy-MM-dd");
                txtusername.Text = rdr["Username"].ToString();
                txtgender.Text=rdr["Gender"].ToString();
                txtage.Text = rdr["Age"].ToString();
                DateTime jd=Convert.ToDateTime(rdr["JoinedDate"].ToString());
                txtjoineddate.Text=jd.ToString("yyyy-MM-dd");
                txtaddress.Text = rdr["Address"].ToString();

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(FileImagesave.PostedFile != null)
            {
                string imgfile = Path.GetFileName(FileImagesave.PostedFile.FileName);
                FileImagesave.SaveAs("D:/New folder/ISA/images/" + imgfile);
                MySqlConnection conn = new MySqlConnection(connectiostring);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText="Update  users set ImagePath='"+ "images/" + imgfile+"' where User_Id='"+ Global.ID+"'";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ltsave.Text = "Image saved.";
                    conn.Close();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
            else
            {
                ltsave.Text = "Please Select Image File.";
            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            txtfirstname.Enabled = true;
            txtlastname.Enabled = true;
            txtemail.Enabled = true;
            txtphoneno.Enabled = true;
            txtdob.Enabled = true;
            txtusername.Enabled = true;
            txtpassword.Enabled = true;
            txtgender.Enabled = true;
            txtage.Enabled = true;
            txtjoineddate.Enabled = true;
            txtaddress.Enabled = true;
            btncancel.Visible = true;
            btnedit.Text = "Save";
        }
    }
}