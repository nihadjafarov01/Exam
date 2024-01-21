using Exam.Business.Repositories.Interfaces;
using Exam.Core.Models.Common;
using Exam.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Exam.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        ExamDbContext _context { get; }

        public GenericRepository(ExamDbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();
        public async Task CreateAsync(T model)
        {
            await Table.AddAsync(model);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            model.IsDeleted = true;
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            Table.Update(model);
            await SaveAsync();
        }
    }
}
