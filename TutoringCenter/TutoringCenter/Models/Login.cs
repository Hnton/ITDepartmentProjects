using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Login
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public String VisitReason { get; set; }
        public String Subject { get; set; }

    }
}