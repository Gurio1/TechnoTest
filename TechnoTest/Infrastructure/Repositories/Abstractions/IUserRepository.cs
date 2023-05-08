﻿using System.Threading.Tasks;
using TechnoTest.Domain.Models;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Infrastructure.Repositories.Abstractions;

public interface IUserRepository : IGenericRepository<User>
{
    Task<Result<User>> CreateAsync(User user);
}