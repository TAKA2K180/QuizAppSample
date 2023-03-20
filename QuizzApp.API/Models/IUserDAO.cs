using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public interface IUserDAO
    {
        List<UserDetails> GetAllUsers();
        UserDetails GetUserById(Guid id);
        void AddUser(Guid Id, string FirstName, string LastName, string EmpId, int Score,DateTime Created,DateTime Taken);
        void UpdateQuestion(UserDetails userDetails);
        void DeleteQuestion(Guid id);
    }
}
