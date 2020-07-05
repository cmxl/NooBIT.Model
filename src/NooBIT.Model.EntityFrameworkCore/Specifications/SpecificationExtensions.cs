using Microsoft.EntityFrameworkCore;
using NooBIT.Model.Specifications;
using System.Linq;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public static class SpecificationExtensions
    {
        public static IQueryable<TEntity> BySpecification<TEntity>(this DbSet<TEntity> query, ISpecification<TEntity> specification) where TEntity : class
            => query.AsQueryable().BySpecification(specification);

        public static IQueryable<TResult> BySpecification<TEntity, TResult>(this DbSet<TEntity> query, ISpecification<TEntity, TResult> specification) where TEntity : class
           => query.AsQueryable().BySpecification(specification);
    }
}
