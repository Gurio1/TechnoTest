using System.Threading.Tasks;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Infrastructure.Repositories.Abstractions;

public interface IUserStateRepository : IGenericRepository<UserState>
{
}