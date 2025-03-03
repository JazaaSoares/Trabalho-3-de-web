using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Persistence.Repositories
{
    public class QualificacaoRepository : BaseRepository, IQualificacaoRepository
    {
        public QualificacaoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Qualificacao>> ListAsync()
        {
            return await _context.Qualificacoes.ToListAsync();
        }
        public async Task AddAsync(Qualificacao qualificacao)
        {
            await _context.Qualificacoes.AddAsync(qualificacao);
        }

        public async Task<Qualificacao> FindByIdAsync(string id)
        {
            return await _context.Qualificacoes.FindAsync(id);
        }

        public void Update(Qualificacao qualificacao)
        {
            _context.Qualificacoes.Update(qualificacao);
        }

        public void Remove(Qualificacao qualificacao)
        {
            _context.Qualificacoes.Remove(qualificacao);
        }
    }
}
