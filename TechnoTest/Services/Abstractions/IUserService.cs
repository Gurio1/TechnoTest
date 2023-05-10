using TechnoTest.Contracts;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserService
{
    Task<Result<UserViewModel>> GetWithGroupAndStateAsync(int id, bool enableTracking = false);
    Task<Result<List<UserViewModel>>> GetAllWithGroupAndStateAsync(bool enableTracking = false);
    Task<Result<UserViewModel>> CreateAsync(User user);
    Task<Result<UserViewModel>> GetUserByNameAsync(string login, bool enableTracking = false);
    Task<Result<UserViewModel>> DeleteUserAsync(int id);
}