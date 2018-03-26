namespace ManagerTask.Data.Helper
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class DbContextHelper<TContext> : IDbContextHelper<TContext> where TContext : DbContext, new()
    {
        public virtual TContext BuildContext(bool enableChangeTracking = true, bool enableLazyLoading = true, bool enableProxyCreation = true)
        {
            var result = new TContext();
            result.Configuration.AutoDetectChangesEnabled = enableChangeTracking;
            result.Configuration.LazyLoadingEnabled = enableLazyLoading;
            result.Configuration.ProxyCreationEnabled = enableProxyCreation;
            return result;
        }

        public virtual T Call<T>(Func<TContext, T> func)
        {
            using (var context = this.BuildContext())
            {
                return func(context);
            }
        }

        public virtual void Call(Action<TContext> action)
        {
            using (var context = this.BuildContext())
            {
                action(context);
            }
        }

        public virtual async Task<T> CallAsync<T>(Func<TContext, Task<T>> func)
        {
            using (var context = this.BuildContext())
            {
                return await func(context).ConfigureAwait(false);
            }
        }

        public virtual async Task CallAsync(Func<TContext, Task> func)
        {
            using (var context = this.BuildContext())
            {
                await func(context).ConfigureAwait(false);
            }
        }

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
