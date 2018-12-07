using LinqKit;
using System;
using System.Linq.Expressions;

namespace NooBIT.Model.Helpers
{
    public static class PredicateHelper
    {
        public static ExpressionStarter<TEntity> ConditionalAnd<TEntity>(this ExpressionStarter<TEntity> starter, Expression<Func<TEntity, bool>> expression, Func<bool> condition) 
            => condition() ? (ExpressionStarter<TEntity>)starter.And(expression) : starter;

        public static ExpressionStarter<TEntity> ConditionalOr<TEntity>(this ExpressionStarter<TEntity> starter, Expression<Func<TEntity, bool>> expression, Func<bool> condition) 
            => condition() ? (ExpressionStarter<TEntity>)starter.Or(expression) : starter;
    }
}