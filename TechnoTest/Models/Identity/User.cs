using System;
using TechnoTest.ViewModels;

namespace TechnoTest.Models.Identity
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; } = new();
        
        public int UserStateId { get; set; }
        public UserState UserState { get; set; } = new();
    }
}