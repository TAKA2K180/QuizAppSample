using Microsoft.EntityFrameworkCore;
using QuizzApp.Core.Models;

namespace QuizzApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Questions> QuestionsDb { get;  set; }
        public DbSet<UserDetails> UserDetailsDb { get; set; }
    }
}
