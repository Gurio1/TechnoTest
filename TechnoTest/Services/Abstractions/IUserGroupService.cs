using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserGroupService
{
    Task<Result<UserGroup>> GetByCodeAsync(string code, bool enableTracking = false);
}