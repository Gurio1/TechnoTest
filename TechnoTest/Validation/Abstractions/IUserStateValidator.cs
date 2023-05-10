using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;

namespace TechnoTest.Validation.Abstractions;

public interface IUserStateValidator
{
    Task<Result<UserState>> ValidateUserStateForNewUser(IUserStateService userStateService, UserState userState);
}