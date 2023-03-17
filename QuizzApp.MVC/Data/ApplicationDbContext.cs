using Microsoft.EntityFrameworkCore;
using QuizzApp.Core.Models;

namespace QuizzApp.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Questions> Questions { get; set; }

        [DbFunction("GetAllQuestions")]
        public IQueryable<Questions> GetAllQuestions()
        {
            return Set<Questions>().FromSqlRaw("EXEC [dbo].[GetAllQuestions]");
        }
    }
}
