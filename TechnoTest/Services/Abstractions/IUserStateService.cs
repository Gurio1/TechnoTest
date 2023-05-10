using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserStateService
{
    Task<UserState?> GetByCodeAsync(string code, bool enableTracking = false);
    Task<Result<UserState>> TrySetToTheNewUser(UserState userState);
}