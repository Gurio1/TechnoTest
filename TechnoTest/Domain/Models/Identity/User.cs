using TechnoTest.Domain.Models.Enums;

namespace TechnoTest.Domain.Models.Identity
{
    public class User : BaseEntity
    {
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; } = new();

        public int UserStateId { get; set; }
        public UserState UserState { get; set; } = new();
    }
}