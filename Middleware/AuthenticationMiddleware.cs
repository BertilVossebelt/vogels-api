using System.Globalization;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using vogels_api.Data;
using vogels_api.Services;

namespace vogels_api.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, AppDbContext appDbContext, JwtService jwtService)
    {
        var token = context.Request.Cookies["jwt"];
       
        if (!token.IsNullOrEmpty())
        {
            string userId = jwtService.Validate(token).Issuer;
            if (!userId.IsNullOrEmpty())
            {
                ulong userIdULong = Convert.ToUInt64(userId);
                context.Items["User"] = appDbContext.Users.Where(u => u.Id == userIdULong);
            }
        }

        await _next(context);
    }
}

public static class AuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthenticationMiddleware>();
    }
}