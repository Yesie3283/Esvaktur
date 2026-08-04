using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class PaymentRequestDto
    {
        public int TourID { get; set; }
        public int UserID { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string Cvc { get; set; }
        public decimal Amount { get; set; }
    }
}