using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IRepository
    {
        int Save();

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate = null)
            where TEntity : class;

        //IEnumerable<TEntity> Get<TEntity>(int page, 
        //    Expression<Func<TEntity, string>> order, 
        //    Expression<Func<TEntity, bool>> predicate = null, 
        //    int pageSize = 1000) where TEntity : class;

        int Insert<TEntity>(TEntity t) where TEntity : class;

        int Update<TEntity>(TEntity t) where TEntity : class;

        int Delete<TEntity>(TEntity t) where TEntity : class;
    }
}
