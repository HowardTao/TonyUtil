using System;
using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using TonyUtil.Logs.Abstractions;
using TonyUtil.Logs.Core;
using TonyUtil.Logs.Formats;

namespace TonyUtil.Logs.Extensions
{
    /// <summary>
    /// 日志服务扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 注册NLog日志操作
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddNLog(this IServiceCollection services)
        {
            services.AddScoped<ILogProviderFactory, NLog.LogProviderFactory>();
            services.AddScoped<ILogFormat, ContentFormat>();
            services.AddScoped<ILogContext, LogContext>();
            services.AddScoped<ILog, Log>();
        }

        /// <summary>
        /// 注册Exceptionless日志操作
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        public static void AddExceptionless(this IServiceCollection services,
            Action<ExceptionlessConfiguration> configAction)
        {
            
        }
    }
}
