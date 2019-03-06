using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutoringCenter.Models
{
    public class Login
    {
        public Login() {
            this.Reasons = new List<Reason>();
            this.ReasonIDs = new List<int>();
            this.Subjects = new List<Subject>();
            this.SubjectIDs = new List<int>();
        }
        public int ID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }          
        public virtual ICollection<Reason> Reasons { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

        [Display(Name = "StudentID")]
        [Required(ErrorMessage ="Required")]
        public int RealStudentID { get; set; }

        [ForeignKey ("RealStudentID")] 
        public virtual Student Student { get; set; }

        [Required(ErrorMessage ="Required")]
        public List<int> ReasonIDs { get; set; }

        [Required(ErrorMessage ="Required")]
        public List<int> SubjectIDs { get; set; }

    }
}


