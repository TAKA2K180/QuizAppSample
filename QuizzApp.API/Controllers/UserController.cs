using Microsoft.AspNetCore.Mvc;
using QuizzApp.API.Models;
using QuizzApp.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizzApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDAO _userDAO;

        public UserController(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<UserDetails> GetAll()
        {
            return _userDAO.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDetails Get(Guid id)
        {
            return _userDAO.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(string FirstName, string LastName, string EmpId, int Score, DateTime Taken)
        {
            _userDAO.AddUser(new Guid(), FirstName, LastName, EmpId, Score, DateTime.Now, Taken);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(UserDetails userDetails)
        {
            _userDAO.UpdateQuestion(userDetails);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userDAO.DeleteQuestion(id);
        }
    }
}
