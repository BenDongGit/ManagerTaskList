namespace ManagerTaskService.ExceptionHandling
{
    using System.Web.Mvc;

    public class ExceptionHandlingAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ExceptionResult(filterContext.Exception);
            filterContext.ExceptionHandled = true;
        }
    }
}