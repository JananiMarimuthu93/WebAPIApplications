using CodeFirstApproach.Interface;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace CodeFirstApproach.Service
{
    public class StandardService : IStandardRepository
    {
        private readonly EfCodeFirstContext _context;

        public StandardService(EfCodeFirstContext context)
        {
            _context = context;
        }

        // Get all standards (with students)
        public async Task<IEnumerable<Standard>> GetAllStandards()
        {
            return await _context.Standards
                                 .Include(s => s.Students)
                                 .ToListAsync();
        }

        // Get standard by Id
        public async Task<Standard?> GetStandardById(int id)
        {
            return await _context.Standards
                                 .Include(s => s.Students)
                                 .FirstOrDefaultAsync(s => s.StandardId == id);
        }

        // Add new standard
        public async Task<Standard> AddStandard(Standard standard)
        {
            await _context.Standards.AddAsync(standard);
            await _context.SaveChangesAsync();
            return standard;
        }

        // Update standard
        public async Task<Standard?> UpdateStandard(int id, Standard standard)
        {
            var existingStandard = await _context.Standards.FirstOrDefaultAsync(s => s.StandardId == id);
            if (existingStandard == null)
            {
                return null;
            }

            existingStandard.StandardName = standard.StandardName;
            existingStandard.Description = standard.Description;

            await _context.SaveChangesAsync();
            return existingStandard;
        }

        // Delete standard
        public async Task<Standard?> DeleteStandard(int id)
        {
            var existingStandard = await _context.Standards.FirstOrDefaultAsync(s => s.StandardId == id);
            if (existingStandard == null)
            {
                return null;
            }

            _context.Standards.Remove(existingStandard);
            await _context.SaveChangesAsync();
            return existingStandard;
        }
    }
}
