using Exam.Business.ViewModels.MemberVMs;
using Exam.Business.ViewModels.SettingVMs;

namespace Exam.Business.Services.Interfaces
{
    public interface ISettingService
    {
        public Task<IEnumerable<SettingListItemVM>> GetAllAsync();
        public Task<SettingUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, SettingUpdateVM vm);
    }
}
