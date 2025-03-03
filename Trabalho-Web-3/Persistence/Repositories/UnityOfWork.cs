using Trabalho_Web_3.Persistence.Repositories;
using Trabalho_Web_3.Persistence;
using Trabalho_Web_3.Domains.Repositories;

namespace Trabalho_Web_3.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}