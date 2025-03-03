using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Services
{
    public class QualificacaoService : IQualificacaoService
    {
        private readonly IQualificacaoRepository _qualificacaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QualificacaoService(IQualificacaoRepository qualificacaoRepository, IUnitOfWork unitOfWork)
        {
            _qualificacaoRepository = qualificacaoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Qualificacao>> ListAsync()
        {
            return await _qualificacaoRepository.ListAsync();
        }

        public async Task<QualificacaoResponse> SaveAsync(Qualificacao qualificacao)
        {
            try
            {
                await _qualificacaoRepository.AddAsync(qualificacao);
                await _unitOfWork.CompleteAsync();

                return new QualificacaoResponse(qualificacao);
            }
            catch (Exception ex)
            {
                return new QualificacaoResponse($"Erro ao salvar qualificacao: {ex.Message}");
            }
        }

        public async Task<QualificacaoResponse> UpdateAsync(string id, Qualificacao qualificacao)
        {

            var existingQualificacao = await _qualificacaoRepository.FindByIdAsync(id);

            if (existingQualificacao == null)
                return new QualificacaoResponse("Qualificacao não encontrado.");

            existingQualificacao.Titulo = qualificacao.Titulo;
            existingQualificacao.Descricao = qualificacao.Descricao;

            try
            {
                _qualificacaoRepository.Update(existingQualificacao);
                await _unitOfWork.CompleteAsync();

                return new QualificacaoResponse(existingQualificacao);
            }
            catch (Exception ex)
            {
                return new QualificacaoResponse($"Erro ao atualizar qualificacao: {ex.Message}");
            }
        }

        public async Task<QualificacaoResponse> DeleteAsync(string id)
        {
            var existingQualificacao = await _qualificacaoRepository.FindByIdAsync(id);

            if (existingQualificacao == null)
                return new QualificacaoResponse("Qualificacao não encontrado.");

            try
            {
                _qualificacaoRepository.Remove(existingQualificacao);
                await _unitOfWork.CompleteAsync();

                return new QualificacaoResponse(existingQualificacao);
            }
            catch (Exception ex)
            {
                return new QualificacaoResponse($"Erro ao deletar qualificacao: {ex.Message}");
            }
        }
    }
}
