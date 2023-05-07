using TechnoTest.Models.Enums;
using TechnoTest.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class ActiveUsersSpecification : BaseSpecifications<User>
{
    public ActiveUsersSpecification()
    {
        SetFilterCondition(u =>u.UserState.Code == UserStatus.Active.ToString());
    }   
}