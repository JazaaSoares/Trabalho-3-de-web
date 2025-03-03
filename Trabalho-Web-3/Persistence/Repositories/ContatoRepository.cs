using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Persistence.Repositories
{
    public class ContatoRepository : BaseRepository, IContatoRepository
    {
        public ContatoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contato>> ListAsync()
        {
            return await _context.Contatos.ToListAsync();
        }
        public async Task AddAsync(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
        }

        public async Task<Contato> FindByIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public void Update(Contato contato)
        {
            _context.Contatos.Update(contato);
        }

        public void Remove(Contato contato)
        {
            _context.Contatos.Remove(contato);
        }
    }
}
