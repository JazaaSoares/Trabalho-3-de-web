using System.ComponentModel.DataAnnotations;

namespace Trabalho_Web_3.Resources
{
    public class SaveProjetoResource
    {
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Link { get; set; }
    }
}
