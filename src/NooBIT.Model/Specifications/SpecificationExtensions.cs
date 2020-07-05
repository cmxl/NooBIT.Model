using System.Linq;

namespace NooBIT.Model.Specifications
{
    public static class SpecificationExtensions
    {
        public static IQueryable<TEntity> BySpecification<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            => specification.Query.Build().Apply(query);

        public static IQueryable<TResult> BySpecification<TEntity, TResult>(this IQueryable<TEntity> query, ISpecification<TEntity, TResult> specification)
           => specification.Query.Build().Apply(query);
    }
}
