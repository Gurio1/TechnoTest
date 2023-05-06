using TechnoTest.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class UserWithGroupSpecification : BaseSpecifications<User>
{
    public UserWithGroupSpecification()
    {
        AddInclude(p =>p.UserGroup);
    }
}