using System.Linq.Expressions;

namespace TechnoTest.Specifications.Abstraction
{
    public interface IBaseSpecifications<T>
    {
        Expression<Func<T, bool>>? FilterCondition { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        bool AsNoTracking { get; }
    }
}