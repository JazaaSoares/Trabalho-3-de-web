using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Domains.Services
{
    public interface IQualificacaoService
    {
        Task<IEnumerable<Qualificacao>> ListAsync();
        Task<QualificacaoResponse> SaveAsync(Qualificacao qualificacao);

        Task<QualificacaoResponse> UpdateAsync(string id, Qualificacao qualificacao);

        Task<QualificacaoResponse> DeleteAsync(string id);
    }
}
