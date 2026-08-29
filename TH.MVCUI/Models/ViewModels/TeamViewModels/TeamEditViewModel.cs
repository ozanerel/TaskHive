using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Takım adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Takım adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }
    }
}