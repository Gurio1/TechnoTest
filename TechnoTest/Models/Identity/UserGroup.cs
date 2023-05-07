using System.Collections;
using System.Collections.Generic;
using TechnoTest.Models.Enums;

namespace TechnoTest.Models.Identity
{
    public class UserGroup : BaseEntity
    {
        public string Code { get; set; } = UserRole.User.ToString();
        public string Description { get; set; } = "Regular User";
    }
}