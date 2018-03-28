namespace ManagerTask.Data.Helper
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// The database context helper interface.
    /// </summary>
    /// <typeparam name="TContext">The context type</typeparam>
    public interface IDbContextHelper<TContext> where TContext : DbContext, new()
    {
        /// <summary>
        /// Calls the function.
        /// </summary>
        /// <typeparam name="T">The return type of function.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>The T object</returns>
        T Call<T>(Func<TContext, T> func);

        /// <summary>
        /// Calls the action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Call(Action<TContext> action);

        /// <summary>
        /// Calls the function async.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>Task wrapper with T object</returns>
        Task<T> CallAsync<T>(Func<TContext, Task<T>> func);

        /// <summary>
        /// Calls the function async.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>The task</returns>
        Task CallAsync(Func<TContext, Task> func);

        /// <summary>
        /// Calls the function with transaction.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>The T object</returns>
        T CallWithTransaction<T>(Func<TContext, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Calls the action with transation.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        void CallWithTransaction(Action<TContext> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Calls the function with transaction async.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>Task wrapper with T object</returns>
        Task<T> CallWithTransactionAsync<T>(Func<TContext, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Calls the function with transaction async.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>The task</returns>
        Task CallWithTransactionAsync(Func<TContext, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
