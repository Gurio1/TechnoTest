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
        
        public async Task<User> GetAsync(IBaseSpecifications<User> baseSpecifications)
        {
            try
            {
                var user = await SpecificationEvaluator<User>
                    .GetQuery(_context.Set<User>(), baseSpecifications)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception($"No user was found who satisfied the specifications.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<User> CreateAsync(User user)
        {
            try
            {
                var existingGroup = await _context.UserGroups.FindAsync(user.UserGroup.Code);
                var existingState = await _context.UserStates.FindAsync(user.UserState.Code);

                if (existingGroup == null || existingState == null)
                {
                    return null;
                }

                user.UserGroup = existingGroup;
                user.UserState = existingState;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't create user: {ex.Message}");
            }
        }
    }
}