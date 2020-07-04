using NooBIT.Model.Entities;
using System.Linq;

namespace NooBIT.Model.Specifications
{
    public static class SpecificationExtensions
    {
        public static IQueryable<TEntity> BySpecification<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification) where TEntity : class, IEntity
            => specification.Query.Build().Apply(query);

        public static IQueryable<TResult> BySpecification<TEntity, TResult>(this IQueryable<TEntity> query, ISpecification<TEntity, TResult> specification) where TEntity : class, IEntity
           => specification.Query.Build().Apply(query);
    }
}
