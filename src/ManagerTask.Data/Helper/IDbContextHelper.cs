namespace ManagerTask.Data.Helper
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public interface IDbContextHelper<TContext> where TContext : DbContext, new()
    {
        T Call<T>(Func<TContext, T> func);

        void Call(Action<TContext> action);

        Task<T> CallAsync<T>(Func<TContext, Task<T>> func);

        Task CallAsync(Func<TContext, Task> func);

        T CallWithTransaction<T>(Func<TContext, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void CallWithTransaction(Action<TContext> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task<T> CallWithTransactionAsync<T>(Func<TContext, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task CallWithTransactionAsync(Func<TContext, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
