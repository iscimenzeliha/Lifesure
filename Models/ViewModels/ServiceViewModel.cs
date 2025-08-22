using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proje7MVC.Models.ViewModels
{
    public class ServiceViewModel
    {
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon alanı zorunludur.")]
        public string Icon { get; set; }

        // API'den gelen görselleri tutar
        public List<string> GeneratedImages { get; set; } = new List<string>();

        // Kullanıcının seçtiği görselin URL'si
        public string SelectedImage { get; set; }
     
    }
}
