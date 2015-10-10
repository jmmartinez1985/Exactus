using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;


namespace JP.Exactus.Core.Service.Filters
{
    public class CoreExcepcionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Evita tirar todo el stacktrace del error mostrado en los apis
        /// </summary>
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
        }
    }
}
