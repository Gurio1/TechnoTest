using System;
using System.ComponentModel.DataAnnotations;
using TechnoTest.Models.Identity;

namespace TechnoTest.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Required] public string Login { get; init; } = default!;
        
        [Required]
        public string Password { get; init; } = default!;
        
        public string UserGroupCode { get; init; } = default!;
    }
}