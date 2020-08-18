using MelhoresPraticas.CrossCutting.BusinessException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelhoresPraticas.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessException bex)
            {
                var errorReturn = new
                {
                    Detail = bex.Detail,
                    Errors = bex.Errors
                };

                context.Result = new ObjectResult(errorReturn)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity
                };

                context.ExceptionHandled = true;

            }
            else if (context.Exception is Exception ex)
            {
                context.Result = new ObjectResult(new
                {
                    Detail = "Aconteceu um problema inexperado, por favor tente mais tarde",
                    Error = ex.Message
                })
                {
                    StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
                };

                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
