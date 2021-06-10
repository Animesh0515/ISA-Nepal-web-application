using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class TrainingBookingModel
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string BookedDate { get; set; }
        public string BookedFor { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public string TrainingJoinedDate { get; set; }
    }
}