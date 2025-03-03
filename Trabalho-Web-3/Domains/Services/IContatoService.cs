using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Domains.Services
{
    public interface IContatoService
    {
        Task<IEnumerable<Contato>> ListAsync();
        Task<ContatoResponse> SaveAsync(Contato contato);

        Task<ContatoResponse> UpdateAsync(string id, Contato contato);

        Task<ContatoResponse> DeleteAsync(string id);
    }
}
