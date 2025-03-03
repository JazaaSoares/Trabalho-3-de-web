using System.ComponentModel.DataAnnotations;

namespace Trabalho_Web_3.Resources
{
    public class SaveExperienciaResource
    {
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
