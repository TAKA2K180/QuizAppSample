using Microsoft.EntityFrameworkCore;
using QuizzApp.API.Data;
using QuizzApp.Core.Models;

namespace QuizzApp.API.Models
{
    public class InstructorDAO : IInstructorDAO
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public InstructorDAO(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void AddInstructor(Guid Id, string Name, string JobDesc)
        {
            var instructor = new InstructorDetails
            {
                Id = Id,
                Name = Name,
                JobDesc = JobDesc
            };
            _applicationDbContext.Add(instructor);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteQuestion(Guid id)
        {
            var deleteIns = new InstructorDetails
            {
                Id = id
            };
            _applicationDbContext.InstructorDetailsDb.Attach(deleteIns);
            _applicationDbContext.InstructorDetailsDb.Remove(deleteIns);
            _applicationDbContext.SaveChanges();
        }

        public List<InstructorDetails> GetAllInstructor()
        {
            return _applicationDbContext.InstructorDetailsDb.ToList();
        }

        public InstructorDetails GetInstructorById(Guid id)
        {
            return _applicationDbContext.InstructorDetailsDb.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateQuestion(InstructorDetails InstructorDetails)
        {
            _applicationDbContext.InstructorDetailsDb.Entry(InstructorDetails).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }
    }
}
