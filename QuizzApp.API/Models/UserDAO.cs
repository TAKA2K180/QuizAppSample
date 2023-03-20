using QuizzApp.API.Data;
using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public class UserDAO : IUserDAO
    {
        private readonly ApplicationDbContext _context;
        public UserDAO(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void AddUser(Guid Id, string FirstName, string LastName, string EmpId, int Score, DateTime Created, DateTime Taken)
        {
            var users = new UserDetails()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                EmpId = EmpId,
                Score = Score,
                Created = Created,
                DateQuizTaken = Taken
            };
            _context.Add(users);
            _context.SaveChanges();
        }

        public void DeleteQuestion(Guid Id)
        {
            var userDetails = new UserDetails()
            {
                Id = Id
            };
            _context.UserDetailsDb.Attach(userDetails);
            _context.UserDetailsDb.Remove(userDetails);
            _context.SaveChanges();
        }

        public List<UserDetails> GetAllUsers()
        {
            return _context.UserDetailsDb.ToList();
        }

        public UserDetails GetUserById(Guid id)
        {
            return _context.UserDetailsDb.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateQuestion(UserDetails userDetails)
        {
            _context.UserDetailsDb.Entry(userDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
