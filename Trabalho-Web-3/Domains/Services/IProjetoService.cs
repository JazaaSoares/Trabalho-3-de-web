using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Domains.Services
{
    public interface IProjetoService
    {
        Task<IEnumerable<Projeto>> ListAsync();
        Task<ProjetoResponse> SaveAsync(Projeto projeto);

        Task<ProjetoResponse> UpdateAsync(string id, Projeto projeto);

        Task<ProjetoResponse> DeleteAsync(string id);
    }
}
