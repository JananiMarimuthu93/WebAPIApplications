using CodeFirstApproach.Interface;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace CodeFirstApproach.Repository
{
    public class StandardService : IStandardRepository
    {
        private readonly EfCodeFirstContext _context;

        public StandardService(EfCodeFirstContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Standard>> GetAllStandards()
        {
            return await _context.Standards.Include(s => s.Students).ToListAsync();
        }

        public async Task<Standard> GetStandardById(int id)
        {
            return await _context.Standards.FirstOrDefaultAsync(s => s.StandardId == id);
        }
    }
}
