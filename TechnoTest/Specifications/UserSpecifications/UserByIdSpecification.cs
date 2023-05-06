using TechnoTest.Models.Identity;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Specifications.UserSpecifications;

public class UserByIdSpecification : BaseSpecifications<User>
{
    public UserByIdSpecification(int id)
    {
        SetFilterCondition(u =>u.Id == id);
    }
}