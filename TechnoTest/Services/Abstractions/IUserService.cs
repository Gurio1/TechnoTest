using TechnoTest.Contracts;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserService
{
    Task<Result<UserViewModel>> GetWithGroupAndStateAsync(int id, bool enableTracking = false);
    Task<Result<IEnumerable<UserViewModel>>> GetAllWithGroupAndStateAsync(bool enableTracking = false);
    Task<Result<UserViewModel>> CreateAsync(User user, string role);
}