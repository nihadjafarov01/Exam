using AutoMapper;
using Exam.Business.ViewModels.SettingVMs;
using Exam.Core.Models;

namespace Exam.Business.Profiles
{
    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<Setting,SettingListItemVM>();
            CreateMap<Setting,SettingUpdateVM>();
            CreateMap<SettingUpdateVM, Setting>();
        }
    }
}
