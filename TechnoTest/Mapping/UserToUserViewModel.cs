using System;
using TechnoTest.Models.Identity;
using TechnoTest.ViewModels;

namespace TechnoTest.Mapping;

public static class UserToUserViewModel
{
    public static UserViewModel ToUserViewModel(this User source)
    {
        return new UserViewModel()
        {
            Id = source.Id,
            Login = source.Login,
            RegistrationDate = source.RegistrationDate,
            UserGroup = source.UserGroup,
            UserState = source.UserState
        };
    }
}