using System;
using TechnoTest.Models.Identity;
using TechnoTest.ViewModels;

namespace TechnoTest.Mapping;

public static class UserRegistrationToUserMapper
{
    public static User ToUser(this UserRegistrationViewModel vm)
    {
        return new User()
        {
            Login = vm.Login,
            Password = vm.Password,
        };
    }
}