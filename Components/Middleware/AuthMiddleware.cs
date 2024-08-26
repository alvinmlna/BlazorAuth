using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace BlazorAuth.Components.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate next;

        public static IDictionary<Guid, ClaimsPrincipal> Logins {  get; private set; } 
            = new ConcurrentDictionary<Guid, ClaimsPrincipal>();

        public AuthMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var claim = Logins[key];

                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim);
                context.Response.Redirect("/");
            } 
                else
            {
                await next(context);
            }
        }
    }
}
