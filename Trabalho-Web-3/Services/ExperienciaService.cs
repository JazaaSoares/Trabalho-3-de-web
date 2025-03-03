using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Services
{
    public class ExperienciaService : IExperienciaService
    {
        private readonly IExperienciaRepository _experienciaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExperienciaService(IExperienciaRepository experienciaRepository, IUnitOfWork unitOfWork)
        {
            _experienciaRepository = experienciaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Experiencia>> ListAsync()
        {
            return await _experienciaRepository.ListAsync();
        }

        public async Task<ExperienciaResponse> SaveAsync(Experiencia experiencia)
        {
            try
            {
                await _experienciaRepository.AddAsync(experiencia);
                await _unitOfWork.CompleteAsync();

                return new ExperienciaResponse(experiencia);
            }
            catch (Exception ex)
            {
                return new ExperienciaResponse($"Erro ao salvar experiencia: {ex.Message}");
            }
        }

        public async Task<ExperienciaResponse> UpdateAsync(string id, Experiencia experiencia)
        {

            var existingExperiencia = await _experienciaRepository.FindByIdAsync(id);

            if (existingExperiencia == null)
                return new ExperienciaResponse("Experiencia não encontrado.");

            existingExperiencia.Titulo = experiencia.Titulo;
            existingExperiencia.Descricao = experiencia.Descricao;
            existingExperiencia.Data = experiencia.Data;

            try
            {
                _experienciaRepository.Update(existingExperiencia);
                await _unitOfWork.CompleteAsync();

                return new ExperienciaResponse(existingExperiencia);
            }
            catch (Exception ex)
            {
                return new ExperienciaResponse($"Erro ao atualizar experiencia: {ex.Message}");
            }
        }

        public async Task<ExperienciaResponse> DeleteAsync(string id)
        {
            var existingExperiencia = await _experienciaRepository.FindByIdAsync(id);

            if (existingExperiencia == null)
                return new ExperienciaResponse("Experiencia não encontrado.");

            try
            {
                _experienciaRepository.Remove(existingExperiencia);
                await _unitOfWork.CompleteAsync();

                return new ExperienciaResponse(existingExperiencia);
            }
            catch (Exception ex)
            {
                return new ExperienciaResponse($"Erro ao deletar experiencia: {ex.Message}");
            }
        }
    }
}
