using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjetoService(IProjetoRepository projetoRepository, IUnitOfWork unitOfWork)
        {
            _projetoRepository = projetoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Projeto>> ListAsync()
        {
            return await _projetoRepository.ListAsync();
        }

        public async Task<ProjetoResponse> SaveAsync(Projeto projeto)
        {
            try
            {
                await _projetoRepository.AddAsync(projeto);
                await _unitOfWork.CompleteAsync();

                return new ProjetoResponse(projeto);
            }
            catch (Exception ex)
            {
                return new ProjetoResponse($"Erro ao salvar projeto: {ex.Message}");
            }
        }

        public async Task<ProjetoResponse> UpdateAsync(string id, Projeto projeto)
        {

            var existingProjeto = await _projetoRepository.FindByIdAsync(id);

            if (existingProjeto == null)
                return new ProjetoResponse("Projeto não encontrado.");

            existingProjeto.Titulo = projeto.Titulo;
            existingProjeto.Link = projeto.Link;

            try
            {
                _projetoRepository.Update(existingProjeto);
                await _unitOfWork.CompleteAsync();

                return new ProjetoResponse(existingProjeto);
            }
            catch (Exception ex)
            {
                return new ProjetoResponse($"Erro ao atualizar projeto: {ex.Message}");
            }
        }

        public async Task<ProjetoResponse> DeleteAsync(string id)
        {
            var existingProjeto = await _projetoRepository.FindByIdAsync(id);

            if (existingProjeto == null)
                return new ProjetoResponse("Projeto não encontrado.");

            try
            {
                _projetoRepository.Remove(existingProjeto);
                await _unitOfWork.CompleteAsync();

                return new ProjetoResponse(existingProjeto);
            }
            catch (Exception ex)
            {
                return new ProjetoResponse($"Erro ao deletar projeto: {ex.Message}");
            }
        }
    }
}
