using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;

namespace Trabalho_Web_3.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContatoService(IContatoRepository contatoRepository)
        {
            this._contatoRepository = contatoRepository;
        }
        public async Task<IEnumerable<Contato>> ListAsync()
        {
            return await _contatoRepository.ListAsync();
        }

        public async Task<Contato> SaveAsync(Contato contato)
        {
            try
            {
                await _contatoRepository.AddAsync(contato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(contato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"An error occurred when saving the contato: {ex.Message}");
            }
        }

        public async Task<ContatoResponse> UpdateAsync(int id, Contato contato)
        {

            var existingContato = await _contatoRepository.FindByIdAsync(id);

            if (existingContato == null)
                return new ContatoResponse("Contato not found.");

            existingContato.Name = contato.Name;

            try
            {
                _contatoRepository.Update(existingContato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(existingContato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"An error occurred when updating the contato: {ex.Message}");
            }
        }

        public async Task<ContatoResponse> DeleteAsync(int id)
        {
            var existingContato = await _contatoRepository.FindByIdAsync(id);

            if (existingContato == null)
                return new ContatoResponse("Contato not found.");

            try
            {
                _contatoRepository.Remove(existingContato);
                await _unitOfWork.CompleteAsync();

                return new ContatoResponse(existingContato);
            }
            catch (Exception ex)
            {
                return new ContatoResponse($"An error occurred when deleting the contato: {ex.Message}");
            }
        }
    }
}
