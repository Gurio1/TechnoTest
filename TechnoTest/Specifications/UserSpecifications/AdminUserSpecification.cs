using TechnoTest.Domain.Models.Enums;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class AdminUserSpecification : BaseSpecifications<User>
{
    public AdminUserSpecification()
    {
        SetFilterCondition(u => u.UserGroup.Code == UserRole.Admin.ToString());
    }
}