using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Domains.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> ListAsync();
        Task AddAsync(Projeto projeto);
        Task<Projeto> FindByIdAsync(string id);
        void Update(Projeto projeto);

        void Remove(Projeto projeto);
    }
}
