using System.ComponentModel.DataAnnotations;

namespace TechnoTest.Contracts
{
    public class UserRegistrationViewModel
    {
        [Required] public string Login { get; set; }

        [Required] public string Password { get; set; }

        public string? UserGroupCode { get; set; }
    }
}