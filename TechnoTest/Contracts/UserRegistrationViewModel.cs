using System.ComponentModel.DataAnnotations;

namespace TechnoTest.Contracts
{
    public class UserRegistrationViewModel
    {
        [Required] public string Login { get; init; } = default!;

        [Required] [MinLength(7)] public string Password { get; init; } = default!;

        public string UserGroupCode { get; init; } = default!;
    }
}