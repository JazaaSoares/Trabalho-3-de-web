using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Services.Communication;

namespace Trabalho_Web_3.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContatoService(IContatoRepository contatoRepository, IUnitOfWork unitOfWork)
        {
            _contatoRepository = contatoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Contato>> ListAsync()
        {
            return await _contatoRepository.ListAsync();
        }

        public async Task<ContatoResponse> SaveAsync(Contato contato)
        {
            try
            {
                await _contatoRepository.AddAsync(contato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(contato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"Erro ao salvar contato: {ex.Message}");
            }
        }

        public async Task<ContatoResponse> UpdateAsync(string id, Contato contato)
        {

            var existingContato = await _contatoRepository.FindByIdAsync(id);

            if (existingContato == null)
                return new ContatoResponse("Contato não encontrado.");

            existingContato.Titulo = contato.Titulo;
            existingContato.Descricao = contato.Descricao;

            try
            {
                _contatoRepository.Update(existingContato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(existingContato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"Erro ao atualizar contato: {ex.Message}");
            }
        }

        public async Task<ContatoResponse> DeleteAsync(string id)
        {
            var existingContato = await _contatoRepository.FindByIdAsync(id);

            if (existingContato == null)
                return new ContatoResponse("Contato não encontrado.");

            try
            {
                _contatoRepository.Remove(existingContato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(existingContato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"Erro ao deletar contato: {ex.Message}");
            }
        }
    }
}
