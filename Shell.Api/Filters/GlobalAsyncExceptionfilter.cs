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
                Serilog.Log.Error(ex, ex.Message);
                var error = new ProblemDetails
                {
                    Type = $"https://httpstatuses.com/{(int)ex.StatusCode}",
                    Title = ex.ErrorTitle,
                    Detail = ex.ToString(),
                    Status = (int)ex.StatusCode,
                };

                context.Result = new ObjectResult(error) { StatusCode = (int)ex.StatusCode };
                context.ExceptionHandled= true;
            }

            return Task.CompletedTask;
        }
    }
}
