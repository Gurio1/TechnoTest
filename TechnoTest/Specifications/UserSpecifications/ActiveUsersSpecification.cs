using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class ActiveUsersSpecification : BaseSpecifications<User>
{
    public ActiveUsersSpecification()
    {
        SetFilterCondition(u => u.UserState.Code == UserStatus.Active.ToString());
    }
}