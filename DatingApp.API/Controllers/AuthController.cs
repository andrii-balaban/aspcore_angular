using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string userName, string password)
        {
            userName = userName.ToLower();

            if (await _repo.UserExists(userName))
            {
                return BadRequest("User name already exists");
            }

            var userToCreate = new User 
            {
                UserName = userName
            };

            var createdUser = await _repo.RegisterAsync(userToCreate, password);

            return StatusCode(201);
        }
    }
}