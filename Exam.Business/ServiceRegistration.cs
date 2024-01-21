using Exam.Business.Profiles;
using Exam.Business.Repositories.Implements;
using Exam.Business.Repositories.Interfaces;
using Exam.Business.Services.Implements;
using Exam.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISettingService, SettingService>();

            return services;
        }
        public static IServiceCollection AddMappers(this IServiceCollection services, string rootpath)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MemberMappingProfile(rootpath));
                opt.AddProfile<SettingMappingProfile>();
            });
            return services;
        }
    }
}
