using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORCA2.Models
{
    public class Expertise
    {
        [Key]
        public int ExpertiseID { get; set; }

        [Required]
        public String Department { get; set; }
        [Required]
        public String Field { get; set; }

        [Display(Name = "Creator Email")]
        public String LinkedEmail { get; set; }

        [Required]
        [Display(Name = "Contact Email")]
        public String ContactEmail { get; set; }
        
        public Boolean Validated { get; set; }
    }
}