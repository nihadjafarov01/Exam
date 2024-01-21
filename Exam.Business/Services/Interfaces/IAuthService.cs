using Exam.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Identity;

namespace Exam.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> Register(RegisterVM vm);
        public Task<SignInResult> Login(LoginVM vm);
        public Task<bool> CreateInits();
        public Task Logout();
    }
}
