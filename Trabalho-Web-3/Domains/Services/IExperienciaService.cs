using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Domains.Services
{
    public interface IExperienciaService
    {
        Task<IEnumerable<Experiencia>> ListAsync();
        Task<ExperienciaResponse> SaveAsync(Experiencia experiencia);

        Task<ExperienciaResponse> UpdateAsync(string id, Experiencia experiencia);

        Task<ExperienciaResponse> DeleteAsync(string id);
    }
}
