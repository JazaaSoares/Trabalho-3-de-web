using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Domains.Repositories
{
    public interface IExperienciaRepository
    {
        Task<IEnumerable<Experiencia>> ListAsync();
        Task AddAsync(Experiencia contato);
        Task<Experiencia> FindByIdAsync(string id);
        void Update(Experiencia contato);

        void Remove(Experiencia contato);
    }
}
