using Microsoft.Extensions.Caching.Memory;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Validation;

public class UserValidator : IUserValidator
{
    public UserValidator()
    {
    }

    public async Task<Result<User>> ValidateUserAsync(IUserService userService, User user)
    {
        return await ValidateUserLoginAsync(userService, user);
    }

    private async Task<Result<User>> ValidateUserLoginAsync(IUserService userService, User user)
    {
        var userResult = await userService.GetUserByNameAsync(user.Login);

        if (userResult.IsSuccessful)
        {
            var message = $"User with login '{user.Login}' already exist!";
            return Result<User>.CreateBadRequesException(message);
        }

        return user;
    }
}