using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class UserByNameSpecification : BaseSpecifications<User>
{
    public UserByNameSpecification(string login)
    {
        SetFilterCondition(p => p.Login == login);
    }
}