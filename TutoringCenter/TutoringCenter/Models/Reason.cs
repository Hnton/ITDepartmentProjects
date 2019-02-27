using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Reason
    {
        [Key]
        public int R_ID { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}