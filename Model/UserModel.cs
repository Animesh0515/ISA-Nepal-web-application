using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string  Role { get; set; }

        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        public string DateofBirth { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int  Age { get; set; }
        public string  Address { get; set; }
        public string JoinedDate { get; set; }
        public int  RowIndex { get; set; }

    }
}