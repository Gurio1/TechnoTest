using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserGroupSpecifications;

public class UserGroupByCodeSpecification : BaseSpecifications<UserGroup>
{
    public UserGroupByCodeSpecification(string groupCode)
    {
        SetFilterCondition(g => g.Code == groupCode);
    }
}