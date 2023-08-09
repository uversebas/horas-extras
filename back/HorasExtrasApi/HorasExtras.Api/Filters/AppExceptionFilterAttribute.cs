using HorasExtras.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HorasExtras.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AppExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var message = context.Exception.Message;

            if ((context.Exception is HorasExtrasException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var msg = new
                {
                    message,
                    ExceptionType = context.Exception.GetType().ToString()
                };

                context.Result = new ObjectResult(msg);
            }
        }
    }
}
