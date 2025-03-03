namespace Trabalho_Web_3.Domains.Models
{
    public class Contato: BaseEntity
    {
        public Contato(string titulo, string descricao)
        {
            Id = Guid.NewGuid().ToString("N");
            Titulo = titulo;
            Descricao = descricao;
            CreatedAt = DateTime.Now;
            DeletedAt = null;
            UpdatedAt = DateTime.Now;
        }

        public string Titulo { get; set;}      

        public string Descricao { get; set; }
    }
}
