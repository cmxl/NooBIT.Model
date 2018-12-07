using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NooBIT.Model.Entities
{
    public class EntitySet<TEntity> : IQueryable<TEntity> where TEntity : class, IEntity
    {
        public EntitySet(IQueryable<TEntity> queryable, IReadEntities entities)
        {
            Queryable = queryable ?? throw new ArgumentNullException(nameof(queryable));
            Entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        protected IQueryable<TEntity> Queryable { get; }
        protected IReadEntities Entities { get; }

        public IEnumerator<TEntity> GetEnumerator() => Queryable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Expression Expression => Queryable.Expression;
        public Type ElementType => Queryable.ElementType;
        public IQueryProvider Provider => Queryable.Provider;
    }
}