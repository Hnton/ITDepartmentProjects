﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}