namespace ManagerTask.Data.Helper
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// The database context helper.
    /// </summary>
    /// <typeparam name="TContext">The context type</typeparam>
    public class DbContextHelper<TContext> : IDbContextHelper<TContext> where TContext : DbContext, new()
    {
        /// <summary>
        /// Builds the context.
        /// </summary>
        /// <param name="enableChangeTracking">Enables the change tracking.</param>
        /// <param name="enableLazyLoading">Enables the lazy loading.</param>
        /// <param name="enableProxyCreation">Enables the proxy creation.</param>
        /// <returns>The database context</returns>
        public virtual TContext BuildContext(bool enableChangeTracking = true, bool enableLazyLoading = true, bool enableProxyCreation = true)
        {
            var result = new TContext();
            result.Configuration.AutoDetectChangesEnabled = enableChangeTracking;
            result.Configuration.LazyLoadingEnabled = enableLazyLoading;
            result.Configuration.ProxyCreationEnabled = enableProxyCreation;
            return result;
        }

        /// <summary>
        /// Calls the function.
        /// </summary>
        /// <typeparam name="T">The return type of function.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>The T object</returns>
        public virtual T Call<T>(Func<TContext, T> func)
        {
            using (var context = this.BuildContext())
            {
                return func(context);
            }
        }

        /// <summary>
        /// Calls the action.
        /// </summary>
        /// <param name="action">The action.</param>
        public virtual void Call(Action<TContext> action)
        {
            using (var context = this.BuildContext())
            {
                action(context);
            }
        }

        /// <summary>
        /// Calls the function async.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>Task wrapper with T object</returns>
        public virtual async Task<T> CallAsync<T>(Func<TContext, Task<T>> func)
        {
            using (var context = this.BuildContext())
            {
                return await func(context).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Calls the function async.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>The task</returns>
        public virtual async Task CallAsync(Func<TContext, Task> func)
        {
            using (var context = this.BuildContext())
            {
                await func(context).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Calls the function with transaction.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>The T object</returns>
        public virtual T CallWithTransaction<T>(Func<TContext, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var context = this.BuildContext())
            {
                using (var tx = context.Database.BeginTransaction(isolationLevel: isolationLevel))
                {
                    var result = func(context);
                    tx.Commit();
                    return result;
                }
            }
        }

        /// <summary>
        /// Calls the action with transation.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        public virtual void CallWithTransaction(Action<TContext> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var context = this.BuildContext())
            {
                using (var tx = context.Database.BeginTransaction(isolationLevel: isolationLevel))
                {
                    action(context);
                    tx.Commit();
                }
            }
        }

        /// <summary>
        /// Calls the function with transaction async.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>Task wrapper with T object</returns>
        public virtual async Task<T> CallWithTransactionAsync<T>(Func<TContext, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var context = this.BuildContext())
            {
                using (var tx = context.Database.BeginTransaction(isolationLevel: isolationLevel))
                {
                    var result = await func(context).ConfigureAwait(false);
                    tx.Commit();
                    return result;
                }
            }
        }

        /// <summary>
        /// Calls the function with transaction async.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>The task</returns>
        public virtual async Task CallWithTransactionAsync(Func<TContext, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var context = this.BuildContext())
            {
                using (var tx = context.Database.BeginTransaction(isolationLevel: isolationLevel))
                {
                    await func(context).ConfigureAwait(false);
                    tx.Commit();
                }
            }
        }
    }
}
