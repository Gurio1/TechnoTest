using System;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Contracts
{
    public class UserViewModel
    {
        public int Id { get; init; }
        public string Login { get; init; }
        public DateTime RegistrationDate { get; init; }

        public UserGroup UserGroup { get; init; }
        public UserState UserState { get; init; }
    }
}