using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvicentChallenge.Models;

namespace AdvicentChallenge.Repository.Interface
{
    public interface ICollegeRepository: IDisposable
    {
        Task<IEnumerable<CollegeModel>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        
        Task<CollegeModel> GetByNameAsync(string name, CancellationToken ct = default(CancellationToken));
        
        Task<CollegeModel> AddAsync(CollegeModel newCollege, CancellationToken ct = default(CancellationToken));
        
        Task<bool> UpdateAsync(CollegeModel college, CancellationToken ct = default(CancellationToken));
        
        Task<bool> DeleteByNameAsync(string name, CancellationToken ct = default(CancellationToken));
    }
}