using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class Guides
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This section Can not be Empty")]

        public int Tour_ID { get; set; }


        [ForeignKey("Tour_ID")]
        public virtual Tours Tour { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    }
}