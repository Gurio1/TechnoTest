using System.Net;
using TechnoTest.Contracts;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Mapping;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserSpecifications;

namespace TechnoTest.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserViewModel>> GetWithGroupAndStateAsync(int id, bool enableTracking)
    {
        var specifications = new UserWithGroupSpecification()
            .And(new UserWithStateSpecification())
            .And(new UserByIdSpecification(id));

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var user = await _userRepository.GetAsync(specifications);

        if (user is not null) return new Result<UserViewModel>(user.ToUserViewModel());

        var message = $"A user with id '{id}' does not exists";
        return new Result<UserViewModel>(new StatusCodeException(HttpStatusCode.NotFound, message));
    }

    public async Task<Result<IEnumerable<UserViewModel>>> GetAllWithGroupAndStateAsync(bool enableTracking = false)
    {
        var specifications = new UserWithGroupSpecification()
            .And(new UserWithStateSpecification());

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var users = await _userRepository.GetAllAsync(specifications);

        if (users is not null) return new Result<IEnumerable<UserViewModel>>(users.Select(x => x.ToUserViewModel()));

        var message = "Users who are satisfied with the specifications cannot be found.";
        return new Result<IEnumerable<UserViewModel>>(new StatusCodeException(HttpStatusCode.NotFound, message));
    }

    public async Task<Result<UserViewModel>> CreateAsync(User user, string role)
    {
        if (role == UserRole.Admin.ToString())
        {
            var adminUser = FindActiveAdminAsync();

            if (adminUser is not null)
            {
                var message = $"User with role '{UserRole.Admin.ToString()}' already exist!";
                return new Result<UserViewModel>(new StatusCodeException(HttpStatusCode.BadRequest, message));
            }

            user.SetAdminDefaults();
        }

        user.RegistrationDate = DateTime.UtcNow;

        var result = await _userRepository.CreateAsync(user);

        return new Result<UserViewModel>(result.GetValue().ToUserViewModel());
    }

    private async Task<User?>? FindActiveAdminAsync()
    {
        var specifications = new ActiveUsersSpecification()
            .And(new AdminUserSpecification());

        var user = await _userRepository.GetAsync(specifications);

        return user;
    }
}