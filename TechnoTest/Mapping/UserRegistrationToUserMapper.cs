﻿using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserRegistrationToUserMapper
{
    public static User ToUser(this UserRegistrationViewModel vm)
    {
        return new User()
        {
            Login = vm.Login,
            Password = vm.Password,
            UserGroup = new UserGroup() { Code = vm.UserGroupCode ?? UserRole.User.ToString() }
        };
    }
}