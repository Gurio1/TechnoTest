using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserGroupSpecifications;
using TechnoTest.Validation.Abstractions;

namespace TechnoTest.Services;

public class UserGroupService : IUserGroupService
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IUserGroupValidator _userGroupValidator;

    public UserGroupService(IUserGroupRepository userGroupRepository, IUserGroupValidator userGroupValidator)
    {
        _userGroupRepository = userGroupRepository;
        _userGroupValidator = userGroupValidator;
    }

    public async Task<UserGroup?> GetByCodeAsync(string code, bool enableTracking = false)
    {
        var specifications = new UserGroupByCodeSpecification(code);
        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        return await _userGroupRepository.GetAsync(specifications);
    }

    public async Task<UserGroup?> GetByCodeWithUsersAsync(string code, bool enableTracking = false)
    {
        var specifications = new UserGroupWithUsers()
            .And(new UserGroupByCodeSpecification(code));

        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        return await _userGroupRepository.GetAsync(specifications);
    }

    public async Task<Result<UserGroup>> TrySetToTheUser(UserGroup userGroup)
    {
        return await _userGroupValidator.ValidateUserGroupForAssignmentAsync(this, userGroup);
    }
}