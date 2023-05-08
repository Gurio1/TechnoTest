using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Specifications.UserStateSpecifications;

public class UserStateByCodeSpecification : BaseSpecifications<UserState>
{
    public UserStateByCodeSpecification(string stateCode)
    {
        SetFilterCondition(s => s.Code == stateCode);
    }
}