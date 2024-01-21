using Exam.Business.ViewModels.MemberVMs;
using System.Linq.Expressions;

namespace Exam.Business.Services.Interfaces
{
    public interface IMemberService
    {
        public Task<IEnumerable<MemberListItemVM>> GetAllAsync();
        public Task CreateAsync(MemberCreateVM vm);
        public Task<MemberUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, MemberUpdateVM vm);
        public Task DeleteAsync(int id);
    }
}
