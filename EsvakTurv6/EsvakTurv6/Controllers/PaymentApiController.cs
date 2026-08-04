using EsvakTurv6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Util;

namespace EsvakTurv6.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentApiController : ApiController
    {
        EsvakTur db = new EsvakTur();

        [HttpPost]
        [Route("process")]
        public IHttpActionResult ProcessPayment([FromBody] PaymentRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.CardNumber))
            {
                return Ok(new PaymentResponseDto
                {
                    IsSuccess = false,
                    Message = "Eksik veya hatalı kart bilgisi girdiniz.",
                });
            }

            string cleanCardNumber = request.CardNumber.Replace(" ", "");

            if (cleanCardNumber.Length != 16)
            {
                return Ok(new PaymentResponseDto
                {
                    IsSuccess = false,
                    Message = "Kart numarası 16 haneli olmalıdır.",
                });
            }

            string transectionId = "TXN-" + Guid.NewGuid().ToString().Substring(0 , 8).ToUpper();




            try
            {
                Bookings newBooking = new Bookings
                {
                    TourID = request.TourID,
                    UserID = request.UserID,
                    BookingDate = DateTime.Now
                };
                db.Bookings.Add(newBooking);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }

            return Ok(new PaymentResponseDto
            {
                IsSuccess = true,
                Message = "Ödeme başarıyla gerçekleşti!",
                TransactionID = transectionId
            });

        }
    }
}