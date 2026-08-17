using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamCreateViewModel
    {
        [Required(ErrorMessage = "Takım adı boş bırakılamaz.")]
        [StringLength(
            100,
            ErrorMessage = "Takım adı en fazla 100 karakter olabilir."
        )]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(
            250,
            ErrorMessage = "Açıklama en fazla 250 karakter olabilir."
        )]
        public string Description { get; set; }
    }
}