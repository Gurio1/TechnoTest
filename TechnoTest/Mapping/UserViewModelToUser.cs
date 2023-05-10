using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserViewModelToUser
{
    public static User ToUser(this UserViewModel source)
    {
        return new User()
        {
            Id = source.Id,
            Login = source.Login,
            RegistrationDate = source.RegistrationDate,
            UserGroup = source.UserGroup.ToUserGroup(),
            UserState = source.UserState.ToUserGroup()
        };
    }
}