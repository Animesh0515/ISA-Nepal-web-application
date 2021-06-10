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
            btnedit.Visible = true;
            btnsaved.Visible = false;

            MySqlConnection conn = new MySqlConnection(connectiostring);
            string query = "Select * from users where User_Id='" + Global.ID + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                txtfirstname.Text = rdr["First_Name"].ToString();
                txtlastname.Text = rdr["Last_Name"].ToString();
                Label1.Text = txtfirstname.Text +" "+ txtlastname.Text;
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
                byte[] bytes = Convert.FromBase64String(rdr["ImageUrl"].ToString());
                imgadm.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                txtpassword.Text = "";

            }
            conn.Close();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(FileImagesave.HasFile)
            {
                string imgfile = Path.GetFileName(FileImagesave.PostedFile.FileName);
                //FileImagesave.SaveAs("G:/FYP/ISA NEPAL(Admin)/AdminPortal/images/" + imgfile);
                System.IO.Stream fs = FileImagesave.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                MySqlConnection conn = new MySqlConnection(connectiostring);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText="Update  users set ImageUrl='"+ base64String + "' where User_Id='"+ Global.ID+"'";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ltsave.Text = "";
                    conn.Close();
                    this.GetProfile();
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "imagemsg(1)", true); 
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
            txtpassword.Enabled = false;
            txtgender.Enabled = false;
            txtage.Enabled = false;
            txtjoineddate.Enabled = false;
            txtaddress.Enabled = false;
            btncancel.Visible = false;
            btnsaved.Visible = false;

            btnedit.Visible = true;
        }

        protected void btnsaved_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectiostring);
            string query;
            if(txtpassword.Text != "" )
            {
                 query = "update users set First_Name='" + txtfirstname.Text + "', Last_Name='" + txtlastname.Text + "', Email='" + txtemail.Text + "',Phone_Number='" + txtphoneno.Text + "',DateOfBirth='" + txtdob.Text + "', Username='" + txtusername.Text + "',Password='" + txtpassword.Text + "',Gender='" + txtgender.Text + "',Age='" + txtage.Text + "',Address='" + txtaddress.Text + "',JoinedDate='" + txtjoineddate.Text + "'where User_Id='" + Global.ID + "'";
            }
            else
            {
                query = "update users set First_Name='" + txtfirstname.Text + "', Last_Name='" + txtlastname.Text + "', Email='" + txtemail.Text + "',Phone_Number='" + txtphoneno.Text + "',DateOfBirth='" + txtdob.Text + "', Username='" + txtusername.Text + "',Gender='" + txtgender.Text + "',Age='" + txtage.Text + "',Address='" + txtaddress.Text + "',JoinedDate='" + txtjoineddate.Text + "'where User_Id='" + Global.ID + "'";

            }
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

        protected void btnrmvpic_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectiostring);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText="Update users set ImageUrl='' where User_Id='" + Global.ID + "' ";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                this.GetProfile();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}