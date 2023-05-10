using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserGroupSpecifications;

public class UserGroupWithUsers : BaseSpecifications<UserGroup>
{
    public UserGroupWithUsers()
    {
        AddInclude(g => g.Users);
    }
}