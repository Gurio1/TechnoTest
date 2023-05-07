using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnoTest.Mapping;
using TechnoTest.Services.Abstractions;
using TechnoTest.ViewModels;

namespace TechnoTest.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        /*public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            return users;
        }*/
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost]
        public async Task<CreatedAtActionResult> Post(UserRegistrationViewModel userVm)
        {
            var user = await _userService.CreateAsync(userVm.ToUser(),userVm.UserGroupCode);
            
            return CreatedAtAction(nameof(Get), new { id = user.Id }, null);
        }
    }
}