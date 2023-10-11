using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public interface IInstructorDAO
    {
        List<InstructorDetails> GetAllInstructor();
        InstructorDetails GetInstructorById(Guid id);
        void AddInstructor(Guid Id, string Name, string JobDesc);
        void UpdateQuestion(InstructorDetails InstructorDetails);
        void DeleteQuestion(Guid id);
    }
}
