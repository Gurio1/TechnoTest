using System.Threading.Tasks;
using TechnoTest.Models.Identity;

namespace TechnoTest.Services.Abstractions;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
}