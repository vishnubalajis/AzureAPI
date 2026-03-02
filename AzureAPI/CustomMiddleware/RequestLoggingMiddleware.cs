namespace AzureAPI.CustomMiddleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
            throw new NotImplementedException();
        }
    }
}
