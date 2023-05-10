using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserStateSpecifications;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Services;

public class UserStateService : IUserStateService
{
    private readonly IUserStateRepository _userStateRepository;
    private readonly IUserStateValidator _userStateValidator;

    public UserStateService(IUserStateRepository userStateRepository, IUserStateValidator userStateValidator)
    {
        _userStateRepository = userStateRepository;
        _userStateValidator = userStateValidator;
    }

    public async Task<UserState?> GetByCodeAsync(string code, bool enableTracking = false)
    {
        var state = await _userStateRepository.GetAsync(new UserStateByCodeSpecification(code));

        return state;
    }

    public Task<Result<UserState>> TrySetToTheNewUser(UserState userState)
    {
        return _userStateValidator.ValidateUserStateForNewUser(this, userState);
    }
}