using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoreIdentity.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name = "Email :")]
        [Required(ErrorMessage = "Email alanı gereklidir")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Adresi Giriniz")]
        public string Email { get; set; }
        [Display(Name = "Telefon :")]
        public string PhoneNumber { get; set; }

        public string PictureUrl { get; set; }
        public IFormFile Picture { get; set; }
        [Display(Name = "İsim :")]
        [Required(ErrorMessage = "İsim alanı gereklidir")]
        public string Name { get; set; }
        [Display(Name = "Soyad :")]
        [Required(ErrorMessage = "Soyadı alanı gereklidir")]
        public string Surname { get; set; }

    }
}
