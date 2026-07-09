using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Areas.Member.ViewModels.ProfileVM
{
    public class EditProfileVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //mevcut fotoğraf
        public string? ImageUrl { get; set; }

        //yeni yüklenecek fotoğraf
        public IFormFile? ImageFile { get; set; }

        //Burada yapılan işlem sadece belirlediğimiz uzantılarda dosya yüklenmesine izin vermek ve maksimum boyutunu 2 MB olarak belirlemek.
        public const int MaxFileSize = 2 * 1024 * 1024;

        public static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".webp"
        };
    }
}