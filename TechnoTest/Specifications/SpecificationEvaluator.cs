using System.Linq;
using TechnoTest.Specifications.Abstraction;
using Microsoft.EntityFrameworkCore;
using TechnoTest.Domain.Models;

namespace TechnoTest.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query,
            IBaseSpecifications<TEntity>? specifications)
        {
            if (specifications is null)
            {
                return query;
            }

            if (specifications.FilterCondition is not null)
            {
                query = query.Where(specifications.FilterCondition);
            }

            query = specifications.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            if (specifications.AsNoTracking)
            {
                query.AsNoTracking();
            }

            return query;
        }
    }
}