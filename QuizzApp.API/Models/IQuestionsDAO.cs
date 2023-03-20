using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public interface IQuestionsDAO
    {
        List<Questions> GetAllQuestions();
        Questions GetQuestionsById(Guid id);
        void AddQuestion(Guid Id,string Question, string Answer, int QuestionId,int AnswerId);
        void UpdateQuestion(Questions questions);
        void DeleteQuestion(Guid id);
    }
}
