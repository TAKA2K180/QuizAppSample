using System.ComponentModel.DataAnnotations.Schema;

namespace QuizzApp.MVC.ViewModel
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpId { get; set; }
        public int Score { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime DateQuizTaken { get; set; }
    }
}
