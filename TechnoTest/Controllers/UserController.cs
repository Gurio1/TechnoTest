using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TechnoTest.Contracts;
using TechnoTest.Contracts.Response;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Mapping;
using TechnoTest.Services.Abstractions;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;
        private readonly IUserGroupValidator _userGroupValidator;
        private readonly IUserValidator _userValidator;
        private readonly IUserStateValidator _userStateValidator;

        public UserController(IUserService userService, IMemoryCache cache, IUserGroupValidator userGroupValidator,
            IUserValidator userValidator,
            IUserStateValidator userStateValidator)
        {
            _userService = userService;
            _cache = cache;
            _userGroupValidator = userGroupValidator;
            _userValidator = userValidator;
            _userStateValidator = userStateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetAll([FromQuery] int pageSize = 4,
            [FromQuery] int pageIndex = 0)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserViewModel>> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            return result.IsSuccessful ? Ok(result.GetValue()) : CreateErrorResponse(result.GetException());
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromServices] IUserGroupService userGroupService,
            [FromServices] IUserStateService userStateService, UserRegistrationViewModel userVm)
        {
            // Check if the data already exists in cache
            if (_cache.TryGetValue(userVm.Login, out _))
            {
                return CreateErrorResponse(
                    new BadRequestException($"User wit this login '{userVm.Login}' already exist! From cache"));
            }

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(6));

            _cache.Set(userVm.Login, userVm, cacheOptions);

            await Task.Delay(TimeSpan.FromSeconds(5));

            var user = userVm.ToUser();

            var userCreatRes = await _userService.CreateAsync(user);

            if (!userCreatRes.IsSuccessful) return CreateErrorResponse(userCreatRes.GetException());

            var createdUser = userCreatRes.GetValue()!;

            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        private ObjectResult CreateErrorResponse(StatusCodeException exception)
        {
            var errorResponse = new ErrorApiResponse((int)exception.StatusCode, exception.Title, exception.Message);

            return new ObjectResult(errorResponse)
            {
                StatusCode = (int)exception.StatusCode,
            };
        }
    }
}