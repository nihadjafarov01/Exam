using Exam.Business.Repositories.Interfaces;
using Exam.Core.Models;
using Exam.DAL.Contexts;

namespace Exam.Business.Repositories.Implements
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(ExamDbContext context) : base(context)
        {
        }
    }
}
