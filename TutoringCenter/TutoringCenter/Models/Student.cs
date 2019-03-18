// Model that has a ID, studentID First and Last Name and is a ICollection of Login
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TutoringCenter.Models
{
    public class Student
    {
        // Primary Key
        [Key]
        public int ID { get; set; }
        
        // Student ID Number
        public int StudentID { get; set; }
        
        // First Name
        public string FName { get; set; }

        // Last Name
        public string LName { get; set; }

        // Logins that are using ICollection
        public virtual ICollection<Login> Logins { get; set; }
    }
}