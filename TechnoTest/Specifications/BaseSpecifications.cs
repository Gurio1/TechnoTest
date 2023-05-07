using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TechnoTest.Models;
using TechnoTest.Specifications.Abstraction;

namespace TechnoTest.Specifications
{
    public class BaseSpecifications<T> : IBaseSpecifications<T>
    {
        public virtual Expression<Func<T, bool>> FilterCondition { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();

        public BaseSpecifications() { }

        public BaseSpecifications(Expression<Func<T,bool>> filterCondition)
        {
            FilterCondition = filterCondition;
        }
        
        public BaseSpecifications<T> And(BaseSpecifications<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        
        protected void SetFilterCondition(Expression<Func<T, bool>> filterExpression)
        {
            FilterCondition = filterExpression;
        }
    }
}