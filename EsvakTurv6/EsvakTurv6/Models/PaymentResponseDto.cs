using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class PaymentResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string TransactionID { get; set; }
    }
}