using TechnoTest.Models.Enums;
using TechnoTest.Models.Identity;

namespace TechnoTest.Specifications.UserSpecifications;

public class AdminUserSpecification : BaseSpecifications<User>
{
    public AdminUserSpecification()
    {
        SetFilterCondition(u =>u.UserGroup.Code == UserRole.Admin.ToString());
    }
}