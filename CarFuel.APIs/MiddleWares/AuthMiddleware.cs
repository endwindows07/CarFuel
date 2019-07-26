using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using CarFuel.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;

namespace CarFuel.APIs.MiddleWares
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly App app;

        public AuthMiddleware(App app)
        {
            this.app = app;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                app.UserId = context.User.Claims.FirstOrDefault(it => it.Type == "Id")?.Value;
            }

            return next(context);
        }
    }

    public static class BuildMiddleWare
    {
        public static IAuthenticationHandler UseAuthenticationHander(this IApplicationBuilder builder)
        {
            return (Microsoft.AspNetCore.Authentication.IAuthenticationHandler)builder.UseMiddleware<AuthMiddleware>();
        }
    }
}

/*
 // แบบอาจารย์ สุเทพ ดีกว่า
    using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using CarFuel.Services; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Http; 

namespace CarFuel.APIs.Middlewares 
{ 
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project 
public class AuthMiddleware 
{ 
private readonly RequestDelegate _next; 

public AuthMiddleware(RequestDelegate next) 
{ 
_next = next; 

} 

public Task Invoke(HttpContext httpContext,App app) 
{ 
if (httpContext.User.Identity.IsAuthenticated) 
{ 
app.UserId = httpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value; //ถ้าข้างซ้ายเป็น null มันจะไม่ไปต่อ มันจะไม่ error แค่ return null 
} 
return _next(httpContext); 
} 
} 

// Extension method used to add the middleware to the HTTP request pipeline. 
public static class AuthMiddlewareExtensions 
{ 
public static IApplicationBuilder UseAuth(this IApplicationBuilder builder) 
{ 
return builder.UseMiddleware<AuthMiddleware>(); 
} 
} 
} 


     */
