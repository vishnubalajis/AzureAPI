namespace AzureAPI.CustomMiddleware
{
    public class RequestGlobalException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestGlobalException> _logger;
        public RequestGlobalException(RequestDelegate next, ILogger<RequestGlobalException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var result = new
                {
                    StatusCode = 500,
                    Message = "Something went wrong"
                };

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
