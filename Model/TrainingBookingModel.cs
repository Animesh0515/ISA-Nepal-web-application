using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class TrainingBookingModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime BookedFor { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
    }
}