// Login is where the data for the student is being stored.
// When the student checked in and out, the Student ID Number, and both the Reason and Subject IDs are stored here

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoringCenter.Models
{
    public class Login
    {
        // Constructor that initializes reasons and subjects
        public Login() {
            this.Reasons = new List<Reason>();
            this.ReasonIDs = new List<int>();
            this.Subjects = new List<Subject>();
            this.SubjectIDs = new List<int>();
        }
        // Primary Key
        public int ID { get; set; }

        // Checked in
        [DataType(DataType.DateTime)]
        public DateTime CheckedIn { get; set; }

        // Checked out
        public DateTime? CheckedOut { get; set; }

        // Interface collection of Reasons
        public virtual ICollection<Reason> Reasons { get; set; }

        // Interface collection of Subjects
        public virtual ICollection<Subject> Subjects { get; set; }

        //Student ID Number
        [Display(Name = "StudentID")]
        [Required(ErrorMessage ="Required")]
        public int RealStudentID { get; set; }

        // Foreign Key for StudentID
        [ForeignKey ("RealStudentID")] 
        public virtual Student Student { get; set; }

        // Reason IDs that are using ICollection
        [Required(ErrorMessage ="Required")]
        public List<int> ReasonIDs { get; set; }

        // Subject IDs that are using ICollection
        [Required(ErrorMessage ="Required")]
        public List<int> SubjectIDs { get; set; }
    }
}


