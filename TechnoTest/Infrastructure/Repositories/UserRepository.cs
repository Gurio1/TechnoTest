using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;

namespace TechnoTest.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(User user)
        {
            await _context.SaveChangesAsync();

            return user;
        }
    }
}