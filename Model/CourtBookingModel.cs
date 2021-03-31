using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPortal.Model
{
    public class CourtBookingModel
    {
        public DateTime BookedDate { get; set; }
        public DateTime BookedFor { get; set; }
        public string Time { get; set; }
    }
}