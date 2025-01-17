using Exam.Business;
using Exam.Business.Profiles;
using Exam.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ExamDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;

                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<ExamDbContext>().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = "/auth/AccessDenied";
                opt.LogoutPath = "/auth/logout";
                opt.LoginPath = "/auth/Login";

                opt.Cookie.Name = "IdentityCookie";
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);

                opt.SlidingExpiration = true;
            });

            builder.Services.AddRepositories();

            builder.Services.AddServices();

            builder.Services.AddMappers(builder.Environment.WebRootPath);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Member}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}