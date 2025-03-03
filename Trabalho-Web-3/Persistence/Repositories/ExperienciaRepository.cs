using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Persistence.Repositories
{
    public class ExperienciaRepository : BaseRepository,IExperienciaRepository
    {
        public ExperienciaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Experiencia>> ListAsync()
        {
            return await _context.Experiencias.ToListAsync();
        }
        public async Task AddAsync(Experiencia experiencia)
        {
            await _context.Experiencias.AddAsync(experiencia);
        }

        public async Task<Experiencia> FindByIdAsync(string id)
        {
            return await _context.Experiencias.FindAsync(id);
        }

        public void Update(Experiencia experiencia)
        {
            _context.Experiencias.Update(experiencia);
        }

        public void Remove(Experiencia experiencia)
        {
            _context.Experiencias.Remove(experiencia);
        }
    }
}
