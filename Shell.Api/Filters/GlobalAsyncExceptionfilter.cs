using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shell.DomainLayer.Exceptions;

namespace Shell.Api.Filters
{
    public class GlobalAsyncExceptionfilter : Attribute, IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception as HttpStatusException;
            if (ex != null)
            {
                var error = new ProblemDetails
                {
                    Type = $"https://httpstatuses.com/{(int)ex.StatusCode}",
                    Title = "An error occurred",
                    Detail = ex.Message,
                    Status = (int)ex.StatusCode
                };

                context.Result = new ObjectResult(error) { StatusCode = (int)ex.StatusCode };
                context.ExceptionHandled= true;
            }

            return Task.CompletedTask;
        }
    }
}
