namespace Api.loja.Middleware
{
    public class AuthenticationMiddleware
    {

        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Custom logic to be executed before the next middleware
            // …
            await _next(context);
            // Custom logic to be executed after the next middleware
            // …
        }
    }
}
