using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services.Abstractions;

namespace TechnoTest.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IdentityContext _context;
        private readonly IUserGroupService _userGroupService;
        private readonly IUserStateService _userStateService;

        public UserRepository(IdentityContext context, IUserGroupService userGroupService,
            IUserStateService userStateService) : base(context)
        {
            _context = context;
            _userGroupService = userGroupService;
            _userStateService = userStateService;
        }

        public async Task<Result<User>> CreateAsync(User user)
        {
            var getGroupResult = await _userGroupService.GetByCodeAsync(user.UserGroup.Code, true);

            if (!getGroupResult.IsSuccessful)
            {
                return new Result<User>(getGroupResult.GetException());
            }

            user.UserGroup = getGroupResult.GetValue();

            var getStateResult = await _userStateService.GetByCodeAsync(user.UserState.Code, true);

            if (!getStateResult.IsSuccessful)
            {
                return new Result<User>(getStateResult.GetException());
            }

            user.UserState = getStateResult.GetValue();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new Result<User>(user);
        }
    }
}