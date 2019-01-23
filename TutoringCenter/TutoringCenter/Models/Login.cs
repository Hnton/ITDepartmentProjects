using System;
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
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }


        //Added by Brian        
        public IEnumerable<SelectListItem> VisitReasonList
        {
            get
            {
                return new List<SelectListItem>
        {
            new SelectListItem { Text = "Tutoring", Value = "1"},
            new SelectListItem { Text = "Printing", Value = "2"},
            new SelectListItem { Text = "Computer Use", Value = "3"},
            new SelectListItem { Text = "Study Space", Value = "4"},
            new SelectListItem { Text = "Math Make-up", Value = "5"},
            new SelectListItem { Text = "Textbook", Value = "6"},
            new SelectListItem { Text = "Kurzweil", Value = "7"},
            new SelectListItem { Text = "Calculator", Value = "8"},
            new SelectListItem { Text = "Microscope", Value = "9"},
            new SelectListItem { Text = "Brainfuse", Value = "10"},
            new SelectListItem { Text = "OTHER", Value = "11"}            
        };
            }
        }

        public IEnumerable<SelectListItem> SubjectList
        {
            get
            {
                return new List<SelectListItem>
        {
            new SelectListItem { Text = "Math", Value = "1"},
            new SelectListItem { Text = "English", Value = "2"},
            new SelectListItem { Text = "Nursing", Value = "3"},
            new SelectListItem { Text = "Computer Science", Value = "4"},
            new SelectListItem { Text = "College 101", Value = "5"},
            new SelectListItem { Text = "Psychology", Value = "6"},
            new SelectListItem { Text = "History", Value = "7"},
            new SelectListItem { Text = "Accounting", Value = "8"},
            new SelectListItem { Text = "Sociology", Value = "9"},
            new SelectListItem { Text = "Business", Value = "10"},
            new SelectListItem { Text = "Criminal Justice", Value = "11"},
            new SelectListItem { Text = "English (Major)", Value = "12"},
            new SelectListItem { Text = "Legal Studies", Value = "13"},
            new SelectListItem { Text = "OTHER", Value = "14"}
        };
            }
        }
    }
}


