using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Domains.Services
{
    public interface IContatoService
    {
        Task<IEnumerable<Contato>> ListAsync();
    }
}
