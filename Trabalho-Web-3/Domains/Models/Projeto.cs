namespace Trabalho_Web_3.Domains.Models
{
    public class Projeto : BaseEntity
    {
        public Projeto(string titulo, string link)
        {
            Id = Guid.NewGuid().ToString("N");
            Titulo = titulo;
            Link = link;
            CreatedAt = DateTime.Now;
            DeletedAt = null;
            UpdatedAt = DateTime.Now;
        }

        public string Titulo { get; set; }

        public string Link { get; set; }
    }
}
