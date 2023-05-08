using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;

namespace TechnoTest.Infrastructure.Repositories;

public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(IdentityContext context) : base(context)
    {
    }
}