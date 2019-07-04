using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvicentChallenge.Models;

namespace AdvicentChallenge.Supervisor.Interface
{
    public interface ICollegeSupervisor
    {
        Task<IEnumerable<CollegeModel>> GetAllCollegeAsync(CancellationToken ct = default);
        Task<CollegeModel> GetCollegeByNameAsync(string name, CancellationToken ct = default);
        Task<CollegeModel> AddCollegeAsync(CollegeModel newCollege, CancellationToken ct = default);
        Task<bool> UpdateCollegeAsync(CollegeModel college, CancellationToken ct = default);
        Task<bool> DeleteCollegeAsync(string name, CancellationToken ct = default);
    }
}