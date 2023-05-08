using Microsoft.EntityFrameworkCore;
using TechnoTest.Domain.Models;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Specifications;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly IdentityContext _context;

    public GenericRepository(IdentityContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync(IBaseSpecifications<TEntity> baseSpecifications)
    {
        var entity = await SpecificationEvaluator<TEntity>
            .GetQuery(_context.Set<TEntity>(), baseSpecifications)
            .FirstOrDefaultAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync(IBaseSpecifications<TEntity> baseSpecifications)
    {
        var entities = await SpecificationEvaluator<TEntity>
            .GetQuery(_context.Set<TEntity>(), baseSpecifications)
            .ToListAsync();
        return entities;
    }
}