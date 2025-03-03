using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Domains.Repositories
{
    public interface IContatoRepository
    {
        Task<IEnumerable<Contato>> ListAsync();
        Task AddAsync(Contato contato);
        Task<Contato> FindByIdAsync(string id);
        void Update(Contato contato);

        void Remove(Contato contato);
    }
}
