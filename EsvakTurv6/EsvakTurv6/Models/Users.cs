using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsvakTurv6.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}