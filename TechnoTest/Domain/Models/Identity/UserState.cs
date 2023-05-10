using TechnoTest.Domain.Models.Enums;

namespace TechnoTest.Domain.Models.Identity
{
    public class UserState : BaseEntity
    {
        public string Code { get; set; } = UserStatus.Active.ToString();
        public string Description { get; set; } = default!;

        public List<User> Users { get; set; }
    }
}