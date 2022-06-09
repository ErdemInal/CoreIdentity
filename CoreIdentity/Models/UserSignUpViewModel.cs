using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Display(Name = "Parola:")]
        [Required(ErrorMessage = "Parola boş geçilemez")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar:")]
        [Compare("Password",ErrorMessage = "Parolalar Eşleşmedi")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "İsim:")]
        [Required(ErrorMessage = "İsim boş geçilemez")]
        public string Name { get; set; }
        [Display(Name = "Soyadı:")]
        [Required(ErrorMessage = "Soyadı boş geçilemez")]
        public string Surname { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email boş geçilemez")]
        public string Email { get; set; }


    }
}
