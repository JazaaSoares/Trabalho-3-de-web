using Trabalho_Web_3.Persistence;

namespace Trabalho_Web_3.Domains.Repositories
{
    public abstract class BaseRepository
    {

        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
