using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserStateVoewModelToUserState
{
    public static UserState ToUserGroup(this UserStateViewModel source)
    {
        return new UserState()
        {
            Id = source.Id,
            Code = source.Code,
            Description = source.Description
        };
    }
}