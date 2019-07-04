using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvicentChallenge.Models;
using AdvicentChallenge.Repository.Interface;
using AdvicentChallenge.Supervisor.Interface;

namespace AdvicentChallenge.Supervisor.Implementation
{
    public class CollegeSupervisor: ICollegeSupervisor
    {
        private readonly ICollegeRepository _collegeRepository;
        public CollegeSupervisor(ICollegeRepository collegeRepository)
        {
            this._collegeRepository = collegeRepository;
        }

        public async Task<IEnumerable<CollegeModel>> GetAllCollegeAsync(CancellationToken ct = default)
        {
            return await this._collegeRepository.GetAllAsync(ct);
        }

        public async Task<CollegeModel> GetCollegeByNameAsync(string name, CancellationToken ct = default)
        {
            return await this._collegeRepository.GetByNameAsync(name, ct);
        }

        #region Not Implemented
#pragma warning disable 1998
        public async Task<CollegeModel> AddCollegeAsync(CollegeModel newCollege, CancellationToken ct = default)
#pragma warning restore 1998
        {
            throw new System.NotImplementedException();
        }

#pragma warning disable 1998
        public async Task<bool> UpdateCollegeAsync(CollegeModel college, CancellationToken ct = default)
#pragma warning restore 1998
        {
            throw new System.NotImplementedException();
        }

#pragma warning disable 1998
        public async Task<bool> DeleteCollegeAsync(string name, CancellationToken ct = default)
#pragma warning restore 1998
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}