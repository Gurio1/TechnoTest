using System.Net;
using TechnoTest.Domain.Exceptions;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services.Abstractions;
using TechnoTest.Specifications.UserStateSpecifications;

namespace TechnoTest.Services;

public class UserStateService : IUserStateService
{
    private readonly IUserStateRepository _userStateRepository;

    public UserStateService(IUserStateRepository userStateRepository)
    {
        _userStateRepository = userStateRepository;
    }

    public async Task<Result<UserState>> GetByCodeAsync(string code, bool enableTracking = false)
    {
        var state = await _userStateRepository.GetAsync(new UserStateByCodeSpecification(code));

        if (state is not null) return new Result<UserState>(state);

        var message = $"State with code '{code}' does not exist!";
        return new Result<UserState>(new StatusCodeException(HttpStatusCode.NotFound, message));
    }
}