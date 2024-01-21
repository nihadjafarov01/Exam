using Exam.Business.Repositories.Interfaces;
using Exam.Core.Models;
using Exam.DAL.Contexts;

namespace Exam.Business.Repositories.Implements
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ExamDbContext context) : base(context)
        {
        }
    }
}
