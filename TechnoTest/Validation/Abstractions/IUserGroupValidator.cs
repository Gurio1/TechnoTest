using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Services.Abstractions;

namespace TechnoTest.Validation.Abstractions;

public interface IUserGroupValidator
{
    Task<Result<UserGroup>>
        ValidateUserGroupForAssignmentAsync(IUserGroupService userGroupService, UserGroup userGroup);
}