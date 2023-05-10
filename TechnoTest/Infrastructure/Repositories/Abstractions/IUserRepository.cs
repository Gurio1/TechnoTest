using System.Threading.Tasks;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Infrastructure.Repositories.Abstractions;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> CreateAsync(User user);
    Task<User?> DeleteAsync(User user);
}