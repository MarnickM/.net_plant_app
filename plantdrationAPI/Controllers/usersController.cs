using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantdrationAPI.DAL;
using plantdrationAPI.Models;

namespace PlantdrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public usersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: api/users/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            var user = await _userRepository.GetByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userRepository.Insert(user);
            await _userRepository.Save();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id,User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetByID(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Update(user);
            await _userRepository.Save();
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            await _userRepository.Save();
            return NoContent();
        }
    }
}
