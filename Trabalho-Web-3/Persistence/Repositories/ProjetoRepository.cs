using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Persistence.Repositories
{
    public class ProjetoRepository : BaseRepository, IProjetoRepository
    {
        public ProjetoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Projeto>> ListAsync()
        {
            return await _context.Projetos.ToListAsync();
        }
        public async Task AddAsync(Projeto projeto)
        {
            await _context.Projetos.AddAsync(projeto);
        }

        public async Task<Projeto> FindByIdAsync(string id)
        {
            return await _context.Projetos.FindAsync(id);
        }

        public void Update(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
        }

        public void Remove(Projeto projeto)
        {
            _context.Projetos.Remove(projeto);
        }
    }
}
