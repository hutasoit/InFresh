using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InFresh.Framework.v1.Interfaces;

namespace InFresh.Framework.v1.Base
{
    public class UnitOfWork : IDisposable, IRepository
    {
        private static UnitOfWork instance = null;
        private static readonly object _lock = new object();

        #region Instance Member
        /// <summary>
        /// 
        /// </summary>
        private UnitOfWork()
        {
            //Context = new InFreshContext();
        }
        /// <summary>
        /// 
        /// </summary>
        private UnitOfWork(string nameOrConnectionString)
        {
            //Context = new InFreshContext(nameOrConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(InFreshContext context)
        {
            //Context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public static UnitOfWork GetInstance(string nameOrConnectionString = null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    if (nameOrConnectionString == null)
                        instance = new UnitOfWork();
                    else
                        instance = new UnitOfWork(nameOrConnectionString);
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InFreshContext Context { get; set; }

        #endregion

        #region CRUD & Store procedure call

        /// <summary>
        /// Get list of Entiy paging
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="page"></param>
        /// <param name="order"></param>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get<TEntity>(int page, Expression<Func<TEntity, string>> order, Expression<Func<TEntity, bool>> predicate = null, int pageSize = 1000) where TEntity : class
        {
            try
            {
                using (Context = new InFreshContext())
                {
                    int skipRows = 0;
                    DbSet<TEntity> set = Context.Set<TEntity>();
                    skipRows = page > 1 ? page * pageSize : 0;

                    var query = set.Where(predicate)
                                .OrderBy(order)
                                .Skip(skipRows).Take(pageSize)
                                .GroupBy(p => new { Total = set.Count() })
                                .FirstOrDefault();

                    return query.Select(p => p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public string Insert<TEntity>(List<TEntity> list) where TEntity : class
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                var obj = set.AddRange(list);
                Save();
                return "0";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //public int Update<TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TEntity>> update) where TEntity : class
        //{
        //    try
        //    {
        //        DbSet<TEntity> set = Context.Set<TEntity>();
        //        //var obj = set.Where(filter).Update(update);
        //        var obj = set.Update<TEntity>(entities, update);

        //        return obj;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.GetHashCode();
        //    }
        //}

        ///// Update list of Entity
        //public int Update<TEntity>(List<TEntity> Entities) where TEntity : class
        //{
        //    try
        //    {
        //        int res = 1;
        //        foreach (TEntity t in Entities)
        //        {
        //            res = Update<TEntity>(t);
        //        }
        //        Save();
        //        return res;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.GetHashCode();
        //    }
        //}

        /// <summary>
        /// Insert or Update an Entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int InsertOrUpdate<TEntity>(TEntity t) where TEntity : class
        {
            int res = 0;
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                IEnumerable<TEntity> list = set.AsEnumerable<TEntity>();

                if (list.Contains(t))
                    res = Update<TEntity>(t);
                //else
                //    res = Insert<TEntity>(t);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        /// <summary>
        /// Insert Or Update List of Entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public int InsertOrUpdate<TEntity>(List<TEntity> ts) where TEntity : class
        {
            int res = 0;
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                IEnumerable<TEntity> list = set.AsEnumerable<TEntity>();

                foreach (TEntity t in ts)
                {

                    if (list.Contains(t))
                        res = Update<TEntity>(t);
                    //else
                    //    res = Insert<TEntity>(t);
                }
                Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = 0;
            }
            return res;
        }

        //public int Delete<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        //{
        //    try
        //    {
        //        DbSet<TEntity> set = Context.Set<TEntity>();
        //        var obj = set.Delete<TEntity>(filter);

        //        return obj;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.GetHashCode();
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long Count<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            DbSet<TEntity> set = Context.Set<TEntity>();
            if (predicate == null)
                return set.Count();
            else
                return set.Count(predicate);
        }

        /// <summary>
        /// Execute SQL syntax
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Execute(string sql, params object[] parameters)
        {
            int i = Context.Database.ExecuteSqlCommand(sql, parameters);
            return i;
        }

        #endregion

        #region IRepository Members
        /// <summary>
        /// 
        /// </summary>
        public int Save()
        {
            try
            {
                Context.SaveChanges();
                return 0;
            }
            catch (Exception ex)
            {
                var oc = ((IObjectContextAdapter)Context).ObjectContext;

                var objectStateEntries = oc.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged);
                foreach (var objectStateEntry in objectStateEntries)
                {
                    oc.Detach(objectStateEntry.Entity);
                }

                StringBuilder sb = new StringBuilder();
                if (ex.GetType() == typeof(DbEntityValidationException))
                {
                    DbEntityValidationException dbex = ex as DbEntityValidationException;

                    foreach (var failure in dbex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    //sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    );
                }
                else
                {
                    if (ex.InnerException.InnerException != null)
                        sb.Append(ex.InnerException.InnerException.Message);
                    else
                        sb.Append(ex.Message);
                    throw new Exception(sb.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            try
            {
                Context = new InFreshContext();
                DbSet<TEntity> set = Context.Set<TEntity>();
                if (predicate == null)
                    return set.AsEnumerable();
                else
                    return set.Where(predicate).AsEnumerable();

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<TEntity>(TEntity t) where TEntity : class
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                var obj = set.Add(t);
                if (obj.Equals(t))
                    return 0;
                else
                    return 1;
            }
            catch (Exception e)
            {
                return e.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update<TEntity>(TEntity t) where TEntity : class
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                var obj = set.Attach(t);
                Context.Entry(t).State = EntityState.Modified;
                if (obj.Equals(t))
                    return 0;
                else
                    return 1;
            }
            catch (Exception e)
            {
                return e.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete<TEntity>(TEntity t) where TEntity : class
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                if (Context.Entry(t).State == EntityState.Detached)
                {
                    set.Attach(t);
                }
                var obj = set.Remove(t);
                if (obj.Equals(t))
                    return 0;
                else
                    return 1;
            }
            catch (Exception e)
            {
                return e.GetHashCode();
            }
        }
        #endregion

        #region IDisposable Member
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    Context.Dispose();
            }
            disposed = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
