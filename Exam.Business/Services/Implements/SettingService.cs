using AutoMapper;
using Exam.Business.Repositories.Interfaces;
using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.SettingVMs;

namespace Exam.Business.Services.Implements
{
    public class SettingService : ISettingService
    {
        ISettingRepository _repo {  get; }
        IMapper _mapper { get; }
        public SettingService(ISettingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SettingListItemVM>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var rdata = _mapper.Map<IEnumerable<SettingListItemVM>>(data);
            return rdata;
        }

        public async Task<SettingUpdateVM> UpdateAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id);
            var vm = _mapper.Map<SettingUpdateVM>(model);
            return vm;
        }

        public async Task UpdateAsync(int id, SettingUpdateVM vm)
        {
            var model = await _repo.GetByIdAsync(id);
            var rmodel = _mapper.Map(vm, model);
            await _repo.UpdateAsync(rmodel);
        }
    }
}
