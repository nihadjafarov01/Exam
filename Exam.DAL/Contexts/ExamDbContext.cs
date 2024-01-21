using Exam.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam.DAL.Contexts
{
    public class ExamDbContext : IdentityDbContext
    {
        public ExamDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
