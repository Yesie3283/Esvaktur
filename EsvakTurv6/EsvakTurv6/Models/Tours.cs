using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class Tours
    {
        public int ID { get; set; }
        public int TourCategories_ID { get; set; }
        [ForeignKey("TourCategories_ID")]
        public virtual TourCategories TourCategories { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public DateTime TourTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Guides> Guides { get; set; }
    }
}