using System.Security.Claims;

namespace DevMetrics.API.Middleware
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = context.User.FindFirst(ClaimTypes.Name)?.Value;

                if (Guid.TryParse(userId, out var parsedId))
                {
                    context.Items["UserId"] = parsedId;
                }

                context.Items["Username"] = username;
            }

            await _next(context);
        }
    }
}
