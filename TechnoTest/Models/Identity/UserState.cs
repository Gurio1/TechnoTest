using TechnoTest.Models.Enums;

namespace TechnoTest.Models.Identity
{
    public class UserState : BaseEntity
    {
        public string Code { get; set; } = UserStatus.Active.ToString();
        public string Description { get; set; } = "Active User";
    }
}