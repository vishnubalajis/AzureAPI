using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AzureAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("Exception caught in filter");

            context.Result = new ObjectResult(new
            {
                Message = "Something went wrong",
                Error = context.Exception.Message
            })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
