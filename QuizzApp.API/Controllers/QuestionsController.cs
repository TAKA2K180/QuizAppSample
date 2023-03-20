using Microsoft.AspNetCore.Mvc;
using QuizzApp.API.Models;
using QuizzApp.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizzApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionsDAO _questionsDAO;

        public QuestionsController(QuestionsDAO questions)
        {
            _questionsDAO = questions;
        }
        // GET: api/<QuestionsController>
        [HttpGet]
        public List<Questions> GetAll()
        {
            return _questionsDAO.GetAllQuestions();
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public Questions Get(Guid id)
        {
            return _questionsDAO.GetQuestionsById(id);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public void Post([FromBody] Guid Id, string Question, string Answer)
        {
            _questionsDAO.AddQuestion(new Guid(),Question,Answer,1,1);
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(Questions questions)
        {
            _questionsDAO.UpdateQuestion(questions);
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _questionsDAO.DeleteQuestion(id);
        }
    }
}
