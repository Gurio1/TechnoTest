using TechnoTest.Contracts;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Mapping;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserSpecifications;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Services;

public class UserService : IUserService
{
    private readonly IUserGroupService _userGroupService;
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;
    private readonly IUserStateService _userStateService;

    public UserService(IUserRepository userRepository, IUserValidator userValidator, IUserStateService userStateService,
        IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
        _userRepository = userRepository;
        _userValidator = userValidator;
        _userStateService = userStateService;
    }

    public async Task<Result<UserViewModel>> GetUserByIdAsync(int id, bool enableTracking = false)
    {
        var specifications = new UserByIdSpecification(id);

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var user = await _userRepository.GetAsync(specifications);

        if (user is not null) return user.ToUserViewModel();

        var message = $"A user with id '{id}' does not exists";
        return Result<UserViewModel>.CreateNotFoundException(message);
    }

    public async Task<Result<UserViewModel>> GetUserByNameAsync(string login, bool enableTracking = false)
    {
        var specifications = new UserByNameSpecification(login);

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var user = await _userRepository.GetAsync(specifications);

        if (user is not null) return user.ToUserViewModel();

        var message = $"A user with name '{login}' does not exists";
        return Result<UserViewModel>.CreateNotFoundException(message);
    }

    public async Task<Result<UserViewModel>> GetWithGroupAndStateAsync(int id, bool enableTracking = false)
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
        return Result<UserViewModel>.CreateNotFoundException(message);
    }

    public async Task<Result<List<UserViewModel>>> GetAllWithGroupAndStateAsync(bool enableTracking = false)
    {
        var specifications = new UserWithGroupSpecification()
            .And(new UserWithStateSpecification());

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var users = await _userRepository.GetAllAsync(specifications);

        if (users.Any()) return new List<UserViewModel>(users.Select(x => x.ToUserViewModel()));

        const string message = "Users who are satisfied with the specifications cannot be found.";
        return Result<List<UserViewModel>>.CreateNotFoundException(message);
    }

    public async Task<Result<UserViewModel>> CreateAsync(User user)
    {
        var valRes = await _userValidator.ValidateUserAsync(this, user);
        if (!valRes.IsSuccessful) return new Result<UserViewModel>(valRes.GetException());

        var userGroupVal = await _userGroupService.TrySetToTheUser(user.UserGroup);
        if (!userGroupVal.IsSuccessful) return new Result<UserViewModel>(userGroupVal.GetException());

        user.UserGroup = userGroupVal.GetValue()!;

        var userStateVal = await _userStateService.TrySetToTheNewUser(user.UserState);
        if (!userStateVal.IsSuccessful) return new Result<UserViewModel>(userStateVal.GetException());

        user.UserState = userStateVal.GetValue()!;

        user.RegistrationDate = DateTime.UtcNow;

        var result = await _userRepository.CreateAsync(user);

        if (result is not null) return result.ToUserViewModel();

        return Result<UserViewModel>.CreateServerErrorException(
            $"An error occured when trying to add user with user login '{user.Login}' to the DB");
    }

    public async Task<Result<UserViewModel>> DeleteUserAsync(int id)
    {
        var userRes = await GetUserByIdAsync(id);
        if (!userRes.IsSuccessful) return new Result<UserViewModel>(userRes.GetException());

        var state = await _userStateService.GetByCodeAsync(UserStatus.Blocked.ToString());

        if (state is null)
            return new Result<UserViewModel>(
                new ServerErrorException($"Can not found user state :{UserStatus.Blocked.ToString()}"));

        var user = userRes.GetValue()!.ToUser();

        user.UserState = state;

        var result = await _userRepository.DeleteAsync(user);
        if (result is not null) return result.ToUserViewModel();

        return Result<UserViewModel>.CreateServerErrorException($"Cant delete user with user login '{user.Login}'");
    }
}