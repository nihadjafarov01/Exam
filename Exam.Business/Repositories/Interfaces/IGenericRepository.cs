using Exam.Core.Models.Common;

namespace Exam.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task SaveAsync();
        public Task CreateAsync(T model);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(int id);
    }
}
