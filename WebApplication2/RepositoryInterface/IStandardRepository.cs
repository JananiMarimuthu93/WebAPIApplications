using WebApplication2.Models;

namespace CodeFirstApproach.Interface
{
    public interface IStandardRepository
    {
        Task<IEnumerable<Standard>> GetAllStandards();
        Task<Standard?> GetStandardById(int id);
        Task<Standard> AddStandard(Standard standard);
        Task<Standard?> UpdateStandard(int id, Standard standard);
        Task<Standard?> DeleteStandard(int id);
    }
}
