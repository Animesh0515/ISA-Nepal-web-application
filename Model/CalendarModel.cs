using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class CalendarModel
    {
        public int ID { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string  Venue { get; set; }
    }
}