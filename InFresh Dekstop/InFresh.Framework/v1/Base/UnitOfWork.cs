using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InFresh.Framework.v1.Interfaces;

namespace InFresh.Framework.v1.Base
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IRepository))]
    public class UnitOfWork : IRepository
    {
        #region IRepository Members
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            IEnumerable<TEntity> data = null;
            InFreshContext context = null;
            try
            {
                using (context = new InFreshContext())
                {
                    DbSet<TEntity> set = context.Set<TEntity>();
                    if (predicate == null)
                        data = set.AsEnumerable();
                    else
                        data = set.Where(predicate).AsEnumerable();

                }
            }
            catch (Exception ex)
            {
                var oc = ((IObjectContextAdapter)context).ObjectContext;

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
            finally
            {
                context.Dispose();
                //GC.SuppressFinalize(this);
            }
            return new List<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="page"></param>
        /// <param name="order"></param>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get<TEntity>(int page, Expression<Func<TEntity, string>> order, 
                                            Expression<Func<TEntity, bool>> predicate = null, 
                                            int pageSize = 1000) where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Insert<TEntity>(TEntity t) where TEntity : class
        {
            int TResult = -1;
            InFreshContext context = null;
            try
            {
                using (context = new InFreshContext())
                {
                    DbSet<TEntity> set = context.Set<TEntity>();
                    var obj = set.Add(t);
                    if (obj.Equals(t))
                        TResult = 0;
                    else
                        TResult = 1;

                    if (TResult == 0)
                        context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TResult = -1;
                var oc = ((IObjectContextAdapter)context).ObjectContext;

                var objectStateEntries = oc.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Added);
                foreach (var objectStateEntry in objectStateEntries)
                    oc.Detach(objectStateEntry.Entity);

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
            finally
            {
                context.Dispose();
                //GC.SuppressFinalize(this);
            }

            return TResult.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string Insert<TEntity>(IList<TEntity> dt) where TEntity : class
        {
            int TResult = -1;
            InFreshContext context = null;
            try
            {
                using (context = new InFreshContext())
                {
                    DbSet<TEntity> set = context.Set<TEntity>();
                    foreach (var t in dt)
                    {
                        var obj = set.Add(t);
                        if (obj.Equals(t))
                            TResult = 0;
                        else
                        {
                            TResult = 1;
                            break;
                        }
                    }

                    if (TResult == 0)
                        context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                TResult = -1;
                var oc = ((IObjectContextAdapter)context).ObjectContext;

                var objectStateEntries = oc.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Added);
                foreach (var objectStateEntry in objectStateEntries)
                    oc.Detach(objectStateEntry.Entity);
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

            return TResult.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Update<TEntity>(TEntity t) where TEntity : class
        {
            int TResult = -1;
            InFreshContext context = null;
            try
            {
                using (context = new InFreshContext())
                {
                    DbSet<TEntity> set = context.Set<TEntity>();
                    var obj = set.Attach(t);
                    context.Entry(t).State = EntityState.Modified;
                    if (obj.Equals(t))
                        TResult = 0;
                    else
                        TResult = 1;

                    if (TResult == 0)
                        context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TResult = -1;
                var oc = ((IObjectContextAdapter)context).ObjectContext;

                var objectStateEntries = oc.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Modified);
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
            finally
            {
                context.Dispose();
                //GC.SuppressFinalize(this);
            }

            return TResult.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string Update<TEntity>(IList<TEntity> dt) where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Delete<TEntity>(TEntity t = null) where TEntity : class
        {
            int TResult = -1;
            InFreshContext context = null;
            try
            {
                using (context = new InFreshContext())
                {
                    DbSet<TEntity> set = context.Set<TEntity>();
                    if (context.Entry(t).State == EntityState.Detached)
                        set.Attach(t);
                    var obj = set.Remove(t);
                    if (obj.Equals(t))
                        TResult = 0;
                    else
                        TResult = 1;

                    if (TResult == 0)
                        context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TResult = -1;
                var oc = ((IObjectContextAdapter)context).ObjectContext;

                var objectStateEntries = oc.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Added);
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
            finally
            {
                context.Dispose();
                //GC.SuppressFinalize(this);
            }

            return TResult.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string Delete<TEntity>(IList<TEntity> dt) where TEntity : class
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
