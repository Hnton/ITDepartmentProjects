// Model that creates the reasons which has a ID, Name, status (Enabled or Disabled) and uses interfaces with Login

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutoringCenter.Models
{
    public class Subject
    {
        // Primary Key
        [Key]
        public int S_ID { get; set; }

        // Reason Name
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        // Status (Enabled or Disabled)
        public bool Status { get; set; }

        // Login that are using ICollection
        public virtual ICollection<Login> Logins { get; set; }
    }
}