using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;

namespace TechnoTest.Validation.Abstractions;

public interface IUserValidator
{
    Task<Result<User>> ValidateUserAsync(IUserService userService, User user);
}