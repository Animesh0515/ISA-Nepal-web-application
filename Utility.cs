using AdminPortal.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal
{
    public class Utility
    {
        static string connectionstring = DatabaseConnectionModel.ConnectionString();

        public static List<LoginModel> Userdetails()
        {
            List<LoginModel> loginModellst = new List<LoginModel>();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            string query = "select * from users";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader fetch_query = cmd.ExecuteReader();
                while(fetch_query.Read())
                {
                    LoginModel loginModel = new LoginModel();
                    loginModel.Role = fetch_query["Role"].ToString();
                    loginModel.Username = fetch_query["Username"].ToString();
                    loginModel.Password = fetch_query["Password"].ToString();
                    loginModellst.Add(loginModel);
                }
                conn.Close();
                return loginModellst;
            }
            catch(Exception e)
            {
                return null;
            }


        }
    }
}