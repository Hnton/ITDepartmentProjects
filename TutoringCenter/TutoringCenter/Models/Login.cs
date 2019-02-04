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
        
        //Attempted add for Checkboxes
        public bool Tutoring { get; set; }
        public bool Printing { get; set; }
        public bool ComputerUse { get; set; }
        public bool StudySpace { get; set; }
        public bool MathMakeup { get; set; }
        public bool Textbook { get; set; }
        public bool Kurzweil { get; set; }
        public bool Calculator { get; set; }
        public bool Microscope { get; set; }
        public bool Brainfuse { get; set; }
        public bool OTHER1 { get; set; }

        public bool Math { get; set; }
        public bool English { get; set; }
        public bool Nursing { get; set; }
        public bool ComputerScience { get; set; }
        public bool College101 { get; set; }
        public bool Psychology { get; set; }
        public bool History { get; set; }
        public bool Accounting { get; set; }
        public bool Sociology { get; set; }
        public bool Business { get; set; }
        public bool CriminalJustice { get; set; }
        public bool EnglishMajor { get; set; }
        public bool LegalStudies { get; set; }
        public bool OTHER2 { get; set; }
        //End of attempted add for Checkboxes

        //Added by Brian        
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
        }

        public IEnumerable<SelectListItem> SubjectList
        {
            get
            {
                return new List<SelectListItem>
        {
            new SelectListItem { Text = "Math", Value = "Math"},
            new SelectListItem { Text = "English", Value = "English"},
            new SelectListItem { Text = "Nursing", Value = "Nursing"},
            new SelectListItem { Text = "Computer Science", Value = "Computer Science"},
            new SelectListItem { Text = "College 101", Value = "College 101"},
            new SelectListItem { Text = "Psychology", Value = "Psychology"},
            new SelectListItem { Text = "History", Value = "History"},
            new SelectListItem { Text = "Accounting", Value = "Accounting"},
            new SelectListItem { Text = "Sociology", Value = "Sociology"},
            new SelectListItem { Text = "Business", Value = "Business"},
            new SelectListItem { Text = "Criminal Justice", Value = "Criminal Justice"},
            new SelectListItem { Text = "English (Major)", Value = "English (Major)"},
            new SelectListItem { Text = "Legal Studies", Value = "Legal Studies"},
            new SelectListItem { Text = "OTHER", Value = "OTHER"}
        };
            }
        }
    }
}


