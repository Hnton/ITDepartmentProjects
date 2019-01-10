﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutoringCenter.Models
{
    public class Login
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public String VisitReason { get; set; }
        public String Subject { get; set; }


        //Added by Brian  
        /*
        public IEnumerable<SelectListItem> VisitReasonList
        {
            get
            {
                return new List<SelectListItem>
        {
            new SelectListItem { Text = "Tutoring", Value = "Tutoring"},
            new SelectListItem { Text = "Printing", Value = "Printing"},
            new SelectListItem { Text = "Computer Use", Value = "Computer Use"},
            new SelectListItem { Text = "Study Space", Value = "Study Space"},
            new SelectListItem { Text = "Math Make-up", Value = "Math Make-up"},
            new SelectListItem { Text = "Textbook", Value = "Textbook"},
            new SelectListItem { Text = "Kurzweil", Value = "Kurzweil"},
            new SelectListItem { Text = "Calculator", Value = "Calculator"},
            new SelectListItem { Text = "Microscope", Value = "Microscope"},
            new SelectListItem { Text = "Brainfuse", Value = "Brainfuse"},
            new SelectListItem { Text = "OTHER", Value = "OTHER"}            
        };
            }
        }*/
    }
}


