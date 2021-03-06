﻿using NooBIT.Model.Specifications;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public class IncludeQueryBuilder<TEntity, TResult> : QueryBuilder<TEntity, TResult>, IIncludeQueryBuilder<TEntity, TResult> where TEntity : class
    {
        private readonly IncludeQuery<TEntity, TResult> _query = new();

        public IIncludeQueryBuilder<TEntity, TResult> Include(string path)
        {
            _query._includes.Add(path);
            return this;
        }

        public override IQuery<TEntity, TResult> Build()
        {
            var query = base.Build();
            _query._baseQuery = query;
            return _query;
        }
    }

    public class IncludeQueryBuilder<TEntity> : IncludeQueryBuilder<TEntity, TEntity>, IIncludeQueryBuilder<TEntity> where TEntity : class
    {
        public IncludeQueryBuilder()
        {
            Select(x => x);
        }
    }
}
