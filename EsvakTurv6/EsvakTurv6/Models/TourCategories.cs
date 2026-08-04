using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class TourCategories
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

        public string Name { get; set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters")]

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Tours> Tours { get; set; }

    }
}