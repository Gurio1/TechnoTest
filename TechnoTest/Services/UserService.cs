using System;
using System.Threading.Tasks;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Mapping;
using TechnoTest.Models.Enums;
using TechnoTest.Models.Identity;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserSpecifications;
using TechnoTest.ViewModels;

namespace TechnoTest.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserViewModel> GetAsync(int id)
    {
        var specifications = new UserWithGroupSpecification()
            .And(new UserWithStateSpecification())
            .And(new UserByIdSpecification(id));

        var user = await _userRepository.GetAsync(specifications);

        return user.ToUserViewModel();
    }

    public async Task<UserViewModel> CreateAsync(User user,string role)
    {
        if (role == UserRole.Admin.ToString())
        {
            if (await FindActiveAdminAsync())
            {
                throw new Exception("Only 1 admin can exist");
            }

            user.UserGroup.Code = UserRole.Admin.ToString();
            user.UserGroup.Description = "Administrator";
        }

        user.RegistrationDate = DateTime.UtcNow;
        
        var result = await _userRepository.CreateAsync(user);

        return result is null ? null : user.ToUserViewModel();
    }

    private async Task<bool> FindActiveAdminAsync()
    {
        var specifications = new ActiveUsersSpecification()
            .And(new AdminUserSpecification());

        var user = await _userRepository.GetAsync(specifications);

        return user is not null;
    }
}