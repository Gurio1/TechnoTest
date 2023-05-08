using Microsoft.AspNetCore.Mvc;
using TechnoTest.Contracts;
using TechnoTest.Contracts.Response;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Mapping;
using TechnoTest.Services.Abstractions;

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
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            var result = await _userService.GetAllWithGroupAndStateAsync();

            return result.IsSuccessful ? Ok(result.GetValue()) : CreateErrorResponse(result.GetException());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var result = await _userService.GetWithGroupAndStateAsync(id);

            return result.IsSuccessful ? Ok(result.GetValue()) : CreateErrorResponse(result.GetException());
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create(UserRegistrationViewModel userVm)
        {
            var result = await _userService.CreateAsync(userVm.ToUser(), userVm.UserGroupCode);

            if (!result.IsSuccessful) return CreateErrorResponse(result.GetException());

            var user = result.GetValue();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        private ObjectResult CreateErrorResponse(StatusCodeException exception)
        {
            var errorResponse = new ErrorApiResponse();
            errorResponse.Errors.Add(exception.Message);
            errorResponse.Status = (int)exception.StatusCode;

            return new ObjectResult(errorResponse)
            {
                StatusCode = (int)exception.StatusCode,
            };
        }
    }
}