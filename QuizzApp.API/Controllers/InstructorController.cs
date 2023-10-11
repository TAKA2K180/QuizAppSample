using Microsoft.AspNetCore.Mvc;
using QuizzApp.API.Models;
using QuizzApp.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizzApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorDAO _instructorDAO;

        public InstructorController(InstructorDAO instructorDAO)
        {
            _instructorDAO = instructorDAO;
        }

        // GET: api/<InstructorController>
        [HttpGet]
        public List<InstructorDetails> Get()
        {
            return _instructorDAO.GetAllInstructor();
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public InstructorDetails Get(Guid id)
        {
            return _instructorDAO.GetInstructorById(id);
        }

        // POST api/<InstructorController>
        [HttpPost]
        public void Post(string Name, string JobDesc)
        {
            _instructorDAO.AddInstructor(new Guid(), Name, JobDesc);
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public void Put(InstructorDetails instructorDetails)
        {
            _instructorDAO.UpdateQuestion(instructorDetails);
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _instructorDAO.DeleteQuestion(id);
        }
    }
}
