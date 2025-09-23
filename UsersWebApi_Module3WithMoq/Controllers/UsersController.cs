using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using UsersWebApi_Module3WithMoq.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userRepository.ListAsync();
            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Username = u.Username,
                Email = u.Email
            });

            return Ok(result);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(id);
            }

            return new UserDto
            {
                Id = user.Id,
                 Name = user.Name,
                Username = user.Username,
                Email = user.Email
            };
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Name=model.Name,
                Username = model.Username,
                Email = model.Email,
                 Password = model.Password
            };

            await _userRepository.AddAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }


        // POST: api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByUsernameAsync(model.Username);
            if (user == null || user.Password != model.Password) // Hash check in real apps
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new
            {
                Message = "Login successful",
                UserId = user.Id,
                user.Username,
                user.Email
            });
        }
    }

    

}
