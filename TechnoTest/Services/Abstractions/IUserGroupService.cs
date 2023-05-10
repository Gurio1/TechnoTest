using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserGroupService
{
    Task<UserGroup?> GetByCodeAsync(string code, bool enableTracking = false);
    Task<UserGroup?> GetByCodeWithUsersAsync(string code, bool enableTracking = false);
    Task<Result<UserGroup>> TrySetToTheUser(UserGroup userGroup);
}