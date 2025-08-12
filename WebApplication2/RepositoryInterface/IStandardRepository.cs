using WebApplication2.Models;

namespace CodeFirstApproach.Interface
{
    public interface IStandardRepository
    {
        Task<IEnumerable<Standard>> GetAllStandards();
        Task<Standard> GetStandardById(int id);

    }
}
