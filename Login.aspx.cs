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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            LoginModel loginModel = new LoginModel();
            string adminid = txtadminid.Text.Trim();
            string password = txtpassword.Text.Trim();
            List<LoginModel> loginModellst = Utility.Userdetails();
            loginModel = loginModellst.Where(x => x.Role == "admin" && x.Username== adminid && x.Password== password).FirstOrDefault();
            Global.ID = loginModel.UserId;
            if (loginModel != null)
            {
                Response.Redirect("Bookings.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),"randontext", "alertmsg()", true);

            }





        }
    }
}