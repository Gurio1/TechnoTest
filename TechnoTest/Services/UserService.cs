using System.Threading.Tasks;
using TechnoTest.Infrastructure.Repositories;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Models.Identity;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserSpecifications;

namespace TechnoTest.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> GetByIdAsync(int id)
    {
        var specifications = new UserWithGroupSpecification()
            .And(new UserWithStateSpecification())
            .And(new UserByIdSpecification(id));

        return  await _userRepository.GetByIdAsync(1, specifications);
    }
}