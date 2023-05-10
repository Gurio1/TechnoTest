using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Validation;

public class UserStateValidator : IUserStateValidator
{
    public UserStateValidator()
    {
    }

    public async Task<Result<UserState>> ValidateUserStateForNewUser(IUserStateService userStateService,
        UserState userState)
    {
        if (userState.Code == UserStatus.Blocked.ToString())
        {
            var exMessage = $"User state for a new user can not be {UserStatus.Blocked.ToString()}!";
            return Result<UserState>.CreateServerErrorException(exMessage);
        }

        var state = await userStateService.GetByCodeAsync(userState.Code, true);

        if (state is not null) return state;

        var message = $"State with code '{userState.Code}' does not exist!";
        return Result<UserState>.CreateNotFoundException(message);
    }
}