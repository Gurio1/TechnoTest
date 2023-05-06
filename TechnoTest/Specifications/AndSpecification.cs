using System;
using System.Linq.Expressions;

namespace TechnoTest.Specifications;

public class AndSpecification<T> : BaseSpecifications<T>
{
    private readonly BaseSpecifications<T> _left;
    private readonly BaseSpecifications<T> _right;

    public AndSpecification(BaseSpecifications<T> left,BaseSpecifications<T> right)
    {
        _left = left;
        _right = right;
    }

    public Expression<Func<T, bool>> GetExpression()
    {
        var leftExpression = _left.FilterCondition;
        var rightExpression = _right.FilterCondition;

        var paramExpr = Expression.Parameter(typeof(T));
        var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

        exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

        var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

        return finalExpr;
    }
}