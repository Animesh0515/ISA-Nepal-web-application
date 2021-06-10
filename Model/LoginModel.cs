using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class LoginModel
    {
        public int UserId { get; set; }
        public string  Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}