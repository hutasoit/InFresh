using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InFresh.Framework.v1.Interfaces
{
    public interface INewRepository
    {
        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate = null)
            where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(int page,
            Expression<Func<TEntity, string>> order,
            Expression<Func<TEntity, bool>> predicate = null,
            int pageSize = 1000) where TEntity : class;

        string Insert<TEntity>(TEntity t) where TEntity : class;

        string Insert<TEntity>(IList<TEntity> dt) where TEntity : class;

        string Update<TEntity>(TEntity t) where TEntity : class;

        string Update<TEntity>(IList<TEntity> dt) where TEntity : class;

        string Delete<TEntity>(TEntity t = null) where TEntity : class;

        string Delete<TEntity>(IList<TEntity> dt) where TEntity : class;
    }
}
