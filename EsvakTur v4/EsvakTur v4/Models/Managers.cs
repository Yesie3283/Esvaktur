using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsvakTur_v4.Models
{
    public class Managers
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

        public string Name { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 characters")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nick Name must be between 3 and 50 characters")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This section Can not be Empty")]
        public string Password { get; set; }

        public DateTime JoinTime { get; set; }

        public bool IsActive { get; set; }
    }
}