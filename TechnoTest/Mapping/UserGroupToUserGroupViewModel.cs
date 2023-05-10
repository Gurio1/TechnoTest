using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserGroupToUserGroupViewModel
{
    public static UserGroupViewModel ToUserGroupViewModel(this UserGroup source)
    {
        return new UserGroupViewModel()
        {
            Id = source.Id,
            Code = source.Code,
            Description = source.Description
        };
    }
}