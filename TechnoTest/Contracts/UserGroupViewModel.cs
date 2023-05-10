using TechnoTest.Domain.Models.Enums;

namespace TechnoTest.Contracts;

public class UserGroupViewModel
{
    public int Id { get; init; }
    public string Code { get; set; } = UserRole.User.ToString();
    public string Description { get; set; } = default!;
}