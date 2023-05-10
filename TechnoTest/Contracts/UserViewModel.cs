using System;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Contracts
{
    public class UserViewModel
    {
        public int Id { get; init; }
        public string Login { get; init; } = default!;
        public DateTime RegistrationDate { get; init; }

        public UserGroupViewModel UserGroup { get; init; } = default!;
        public UserStateViewModel UserState { get; init; } = default!;
    }
}