namespace ManagerTaskService.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;
    using ManagerTask.Data;

    /// <summary>
    /// The ninject dependency resolver
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class
        /// </summary>
        /// <param name="kernelParam">The kernel param</param>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        /// <summary>
        /// Gets the service
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The service object</returns>
        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The service object collection</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Adds the bindings
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IManagerTaskDataAccess>().To<ManagerTaskDataAccess>();
        }
    }
}