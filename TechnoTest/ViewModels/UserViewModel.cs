using System;
using TechnoTest.Models.Identity;

namespace TechnoTest.ViewModels
{
    public class UserViewModel
    {
        public int  Id { get; set; }
        public string Login { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public UserGroup UserGroup { get; set; }
        public UserState UserState { get; set; }
    }
}