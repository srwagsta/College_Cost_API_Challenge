using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdvicentChallenge.DataStorage.Mapping;
using AdvicentChallenge.Models;
using AdvicentChallenge.Repository.Interface;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;

namespace AdvicentChallenge.Repository.Implementation
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly IEnumerable<CollegeModel> _csvDataStore;
        private StreamReader _fileReader;
        private CsvReader _csvReader;
        
        public CollegeRepository(IHostingEnvironment hostingEnvironment)
        {
            string filePath = hostingEnvironment.ContentRootPath + "/DataStorage/advicent_college_costs.csv";
            
            this._fileReader = new StreamReader(filePath);
            this._csvReader = new CsvReader(this._fileReader);

            this._csvReader.Configuration.RegisterClassMap<CollegeCsvMap>();
            this._csvDataStore = this._csvReader.GetRecords<CollegeModel>();
        }

        public void Dispose()
        {
            this._csvReader.Dispose();
            this._fileReader.Dispose();
        }

        public Task<IEnumerable<CollegeModel>> GetAllAsync(CancellationToken ct = default)
        {
            return Task.FromResult(this._csvDataStore);
        }

        public Task<CollegeModel> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return Task.FromResult(this._csvDataStore.FirstOrDefault(college => college.Name.Equals(name)));
        }

        #region Not Implemented

        public Task<CollegeModel> AddAsync(CollegeModel newCollege, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(CollegeModel college, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByNameAsync(string name, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}