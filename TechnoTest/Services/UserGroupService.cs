using System.Net;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserGroupSpecifications;

namespace TechnoTest.Services;

public class UserGroupService : IUserGroupService
{
    private readonly IUserGroupRepository _userGroupRepository;

    public UserGroupService(IUserGroupRepository userGroupRepository)
    {
        _userGroupRepository = userGroupRepository;
    }

    public async Task<Result<UserGroup>> GetByCodeAsync(string code, bool enableTracking = false)
    {
        var specifications = new UserGroupByCodeSpecification(code);
        if (enableTracking)
        {
            specifications.EnableTracking();
        }

        var group = await _userGroupRepository.GetAsync(specifications);

        if (group is not null) return new Result<UserGroup>(group);

        var message = $"Group with code '{code}' does not exist!";

        return new Result<UserGroup>(new StatusCodeException(HttpStatusCode.NotFound, message));
    }
}