namespace ManagerTaskService.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;
    using ManagerTask.Data;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IManagerTaskDataAccess>().To<ManagerTaskDataAccess>();
        }
    }
}