using TechnoTest.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class UserWithStateSpecification : BaseSpecifications<User>
{
    public UserWithStateSpecification()
    {
        AddInclude(u =>u.UserState);
    }
}