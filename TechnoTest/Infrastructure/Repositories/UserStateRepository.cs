using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;

namespace TechnoTest.Infrastructure.Repositories;

public class UserStateRepository : GenericRepository<UserState>, IUserStateRepository
{
    private readonly IdentityContext _context;

    public UserStateRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }
}