using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Models.ViewModels.AppUserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola alanı boş geçilemez!")]
        public string Password { get; set; }
    }
}
