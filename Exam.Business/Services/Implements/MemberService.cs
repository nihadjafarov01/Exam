using AutoMapper;
using Exam.Business.Repositories.Interfaces;
using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.MemberVMs;
using Exam.Core.Models;

namespace Exam.Business.Services.Implements
{
    public class MemberService : IMemberService
    {
        IMemberRepository _repo { get; }
        IMapper _mapper {  get; }

        public MemberService(IMapper mapper, IMemberRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(MemberCreateVM vm)
        {
            var model = _mapper.Map<Member>(vm);
            await _repo.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<MemberListItemVM>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var rdata = _mapper.Map<IEnumerable<MemberListItemVM>>(data);
            return rdata;
        }

        public async Task<MemberUpdateVM> UpdateAsync(int id)
        {
            var model =  await _repo.GetByIdAsync(id);
            var vm = _mapper.Map<MemberUpdateVM>(model);
            return vm;
        }

        public async Task UpdateAsync(int id, MemberUpdateVM vm)
        {
            var model = await _repo.GetByIdAsync(id);
            var rmodel = _mapper.Map(vm,model);
            await _repo.UpdateAsync(model);
        }
    }
}
