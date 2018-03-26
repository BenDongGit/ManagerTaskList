namespace ManagerTaskService.ExceptionHandling
{
    using System;
    using System.Net;
    using System.Net.Mime;
    using System.Web.Mvc;

    public class ExceptionResult : ActionResult
    {
        public Exception Exception { get; private set; }

        public ExceptionResult(Exception e)
        {
            Exception = e ?? throw new ArgumentException("The exception should not be empty");
        }

        /// <summary>
        /// The execute result.
        /// </summary>
        /// <param name="context">The controller context</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("The controller context should not be empty");
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = MediaTypeNames.Text.Plain;

            string msg = Exception.Message;
            if (Exception is AggregateException)
            {
                msg += ":<br>";
                AggregateException ae = (AggregateException)Exception;

                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    msg += e.Message + "<br>";
                }
            }

            response.Write(msg);
        }
    }
}