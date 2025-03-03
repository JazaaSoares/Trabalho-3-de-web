using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Domains.Repositories
{
    public interface IQualificacaoRepository
    {
        Task<IEnumerable<Qualificacao>> ListAsync();
        Task AddAsync(Qualificacao qualificacao);
        Task<Qualificacao> FindByIdAsync(string id);
        void Update(Qualificacao qualificacao);

        void Remove(Qualificacao qualificacao);
    }
}
