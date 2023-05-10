using TechnoTest.Domain.Models.Enums;

namespace TechnoTest.Contracts;

public class UserStateViewModel
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; } = default!;
}