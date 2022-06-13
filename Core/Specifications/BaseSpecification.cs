using Core.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
namespace Core.Specifications
{
    public class BaseSpecification<T>:ISpecifications<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Criteria=criteria;
        }
         public Expression<Func<T,bool>> Criteria{get;}
         public Expression<Func<T,object>> OrderBy{get; private set;} 
         public Expression<Func<T,object>> OrderByDescending{get;private set;}
         public int Take{get; private set;}
         public int Skip{get; private set;}
         public bool IsPagingEnabled{get; private set;}
         
         public List<Expression<Func<T,object>>> Includes{get;}=new List<Expression<Func<T,object>>>();

         protected void AddInclude(Expression<Func<T, object>> includeExpression)
         {
             Includes.Add(includeExpression);
         }
          protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
         {
             OrderBy=orderByExpression;
         }
          protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
         {
            OrderByDescending=orderByDescExpression;
         }
          protected void ApplyPaging(int skip, int take)
         {
            Take=take;
            Skip=skip;
            IsPagingEnabled=true;
         }

         
    }
}