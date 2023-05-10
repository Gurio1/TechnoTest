using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Validation;

public class UserGroupValidator : IUserGroupValidator
{
    public UserGroupValidator()
    {
    }

    public async Task<Result<UserGroup>> ValidateUserGroupForAssignmentAsync(IUserGroupService userGroupService,
        UserGroup userGroup)
    {
        if (userGroup.Code != UserRole.Admin.ToString())
            return await ValidateUserGroupCodeAsync(userGroupService, userGroup);

        return await ValidateAgainAdminAsync(userGroupService, userGroup);
    }

    private async Task<Result<UserGroup>> ValidateUserGroupCodeAsync(IUserGroupService userGroupService,
        UserGroup userGroup)
    {
        var groupFromDb = await userGroupService.GetByCodeAsync(userGroup.Code, true);
        if (groupFromDb is not null) return new Result<UserGroup>(groupFromDb);

        var message = $"Group with code '{userGroup.Code}' does not exist!";
        return Result<UserGroup>.CreateNotFoundException(message);
    }

    private async Task<Result<UserGroup>> ValidateAgainAdminAsync(IUserGroupService userGroupService,
        UserGroup userGroup)
    {
        var groupFromDb = await userGroupService.GetByCodeWithUsersAsync(userGroup.Code, true);
        switch (groupFromDb!.Users.Count(u => u.UserState.Code != UserStatus.Blocked.ToString()))
        {
            case > 1:
            {
                var message =
                    $"System error : Application have more than 1 user with role '{UserRole.Admin.ToString()}'.Please report it to the administrator\n" +
                    $"{PrintUsersWithAdminGroup(groupFromDb!.Users.Where(u => u.UserState.Code != UserStatus.Blocked.ToString()))}";
                return Result<UserGroup>.CreateServerErrorException(message);
            }
            case 1:
            {
                var message = $"User with role '{UserRole.Admin.ToString()}' already exist!";
                return Result<UserGroup>.CreateBadRequesException(message);
            }
            default:
                return groupFromDb!;
        }
    }

    private string PrintUsersWithAdminGroup(IEnumerable<User> users)
    {
        string result = String.Empty;

        foreach (var user in users)
        {
            result += $"{user.Login} - {user.RegistrationDate}\n";
        }

        return result;
    }
}