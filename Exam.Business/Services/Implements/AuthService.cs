using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.AuthVMs;
using Exam.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exam.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<IdentityUser> _userManager {  get; }
        SignInManager<IdentityUser> _signInManager {  get; }
        RoleManager<IdentityRole> _roleManager {  get; }

        public AuthService(RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateInits()
        {
            foreach (var item in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item,
                    });
                }
            }
            IdentityUser user = new IdentityUser
            {
                Email = "admin@gmail.com",
                UserName = "admin123"
            };
            await _userManager.CreateAsync(user, "Admin123");
            IdentityUser user2 = await _userManager.FindByNameAsync("admin123");
            await _userManager.AddToRoleAsync(user2, Roles.Admin.ToString());
            return true;
        }

        public async Task<SignInResult> Login(LoginVM vm)
        {
            IdentityUser user;
            if(vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            SignInResult result = new SignInResult();
            if (user != null)
            {
                result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
                return result;
            }
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterVM vm)
        {
            IdentityUser user = new IdentityUser
            {
                Email = vm.Email,
                UserName = vm.Username
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            return result;
        }
    }
}
