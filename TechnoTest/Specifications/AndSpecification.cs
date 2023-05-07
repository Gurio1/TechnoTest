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
        
        Includes.AddRange(left.Includes);
        Includes.AddRange(right.Includes);
    }
    
    public override Expression<Func<T, bool>> FilterCondition => GetFilterExpression();

    private Expression<Func<T, bool>> GetFilterExpression()
    {
        var leftExpression = _left?.FilterCondition;
        var rightExpression = _right?.FilterCondition;

        if (leftExpression == null && rightExpression == null)
        {
            return null;
        }
        else if (leftExpression == null)
        {
            return rightExpression;
        }
        else if (rightExpression == null)
        {
            return leftExpression;
        }

        var paramExpr = Expression.Parameter(typeof(T));
        var exprBody = Expression.AndAlso(
            Expression.Invoke(leftExpression, paramExpr),
            Expression.Invoke(rightExpression, paramExpr)
        );

        exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

        var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

        return finalExpr;
    }
}