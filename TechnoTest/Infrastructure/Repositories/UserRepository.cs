using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Models.Identity;
using TechnoTest.Specifications;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetByIdAsync(int id, IBaseSpecifications<User> baseSpecifications = null)
        {
            try
            {
                var user = await SpecificationEvaluator<User>
                    .GetQuery(_context.Set<User>(), baseSpecifications)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception($"Couldn't find user with id={id}");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve user with id={id}: {ex.Message}");
            }
        }
    }
}