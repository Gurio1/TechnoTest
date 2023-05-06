using System.Threading.Tasks;
using TechnoTest.Models.Identity;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Infrastructure.Repositories.Abstractions;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id, IBaseSpecifications<User> baseSpecifications = null);
}