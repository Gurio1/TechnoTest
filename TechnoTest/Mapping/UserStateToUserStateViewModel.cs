using TechnoTest.Contracts;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Mapping;

public static class UserStateToUserStateViewModel
{
    public static UserStateViewModel ToUserStateViewModel(this UserState source)
    {
        return new UserStateViewModel()
        {
            Id = source.Id,
            Code = source.Code,
            Description = source.Description
        };
    }
}