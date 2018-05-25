using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TonyUtil.Helpers;

namespace TonyUtil.Webs.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions
    {
        public static IServiceCollection AddXsrfToken(this IServiceCollection services)
        {
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            return services;
        }

        public static IApplicationBuilder UseXsrfToken(this IApplicationBuilder app)
        {
            var antiforgery = Ioc.Create<IAntiforgery>();
            app.Use(next => context =>
            {
                if (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(context.Request.Path.Value, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new Microsoft.AspNetCore.Http.CookieOptions {HttpOnly = false});
                }
                return next(context);
            });
            return app;
        }
    }
}
