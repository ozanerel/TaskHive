using System.ComponentModel.DataAnnotations;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.ViewModels.AppUserViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Şifre en az 6 karakter olmalıdır."
        )]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez!")]
        [DataType(DataType.Password)]
        [Compare(
            "Password",
            ErrorMessage = "Şifreler eşleşmiyor."
        )]
        public string ConfirmPassword { get; set; }

        public List<Role> Roles { get; set; } = new();
    }
}