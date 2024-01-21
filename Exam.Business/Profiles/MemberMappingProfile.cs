using AutoMapper;
using Exam.Business.Helpers;
using Exam.Business.ViewModels.MemberVMs;
using Exam.Core.Models;

namespace Exam.Business.Profiles
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile(string rootPath)
        {
            CreateMap<Member,MemberListItemVM>();
            CreateMap<Member, MemberUpdateVM>();

            CreateMap<MemberCreateVM, Member>()
                .ForMember(m => m.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = await src.ImageFile.SaveAndProvideNameAsync(rootPath);
                    }
                });

            CreateMap<MemberUpdateVM, Member>()
                .ForMember(m => m.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = await src.ImageFile.SaveAndProvideNameAsync(rootPath);
                    }
                });
        }
    }
}
