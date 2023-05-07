using System;
using TechnoTest.Models.Identity;

namespace TechnoTest.ViewModels
{
    public class UserViewModel
    {
        public int  Id { get; init; }
        public string Login { get; init; }
        public DateTime RegistrationDate { get; init; }
        
        public UserGroup UserGroup { get; init; }
        public UserState UserState { get; init; }
    }
}