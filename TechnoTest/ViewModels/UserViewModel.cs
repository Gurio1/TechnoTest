﻿using System;
using TechnoTest.Models.Identity;

namespace TechnoTest.ViewModels
{
    public class UserViewModel
    {
        public int  Id { get; set; }
        public string Login { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        
        public int UserStateId { get; set; }
        public UserState UserState { get; set; }
    }
}