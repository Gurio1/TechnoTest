using TechnoTest.Domain.Models;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Infrastructure.Repositories.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(IBaseSpecifications<TEntity> baseSpecifications);

    Task<IEnumerable<TEntity>?> GetAllAsync(IBaseSpecifications<TEntity> baseSpecifications);
}