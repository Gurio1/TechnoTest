using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserGroupViewModelToUserGroup
{
    public static UserGroup ToUserGroup(this UserGroupViewModel source)
    {
        return new UserGroup()
        {
            Id = source.Id,
            Code = source.Code,
            Description = source.Description
        };
    }
}