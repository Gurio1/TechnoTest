using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class UserByIdSpecification : BaseSpecifications<User>
{
    public UserByIdSpecification(int id)
    {
        SetFilterCondition(u => u.Id == id);
    }
}