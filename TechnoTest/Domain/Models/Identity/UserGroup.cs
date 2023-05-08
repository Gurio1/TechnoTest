using TechnoTest.Domain.Models.Enums;

namespace TechnoTest.Domain.Models.Identity
{
    public class UserGroup : BaseEntity
    {
        public string Code { get; set; } = UserRole.User.ToString();
        public string Description { get; set; } = "Regular User";
    }
}