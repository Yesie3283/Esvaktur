using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsvakTurv6.Models
{
    public class Bookings
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int TourID { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual Users User { get; set; }

        [ForeignKey("TourID")]
        public virtual Tours Tour { get; set; }
    }
}