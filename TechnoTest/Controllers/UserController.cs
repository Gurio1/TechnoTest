using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnoTest.Infrastructure;
using TechnoTest.Models.Identity;
using TechnoTest.ViewModels;

namespace TechnoTest.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly IdentityContext _db;

        public UserController(IdentityContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            return users;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
        [HttpPost]
        public async Task Post(UserRegistrationViewModel userVM)
        {
        }
    }
}