using QuizzApp.API.Data;
using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public class QuestionsDAO : IQuestionsDAO
    {
        private readonly ApplicationDbContext _context;

        public QuestionsDAO(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void AddQuestion(Guid Id, string Question, string Answer, int QuestionId, int AnswerId)
        {
            var _question = new Questions
            {
                Id = Id,
                Question = Question,
                Answer = Answer,
                AnswerId = AnswerId
            };
            _context.QuestionsDb.Add(_question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(Guid id)
        {
            var question = new Questions()
            {
                Id = id
            };
            _context.QuestionsDb.Attach(question);
            _context.QuestionsDb.Remove(question);
            _context.SaveChanges();

        }

        public List<Questions> GetAllQuestions()
        {
           return _context.QuestionsDb.ToList();
        }

        public Questions GetQuestionsById(Guid id)
        {
            return _context.QuestionsDb.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateQuestion(Questions questions)
        {
            _context.QuestionsDb.Entry(questions).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
