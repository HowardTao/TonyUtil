﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TonyUtil.Datas.Ef.Configs;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.UnitOfWorks;

namespace TonyUtil.Datas.Ef
{
    /// <summary>
    /// 服务扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> configAction)
            where TService:class ,IUnitOfWork
            where TImplementation:UnitOfWorkBase,TService
        {
            services.AddDbContext<TImplementation>(configAction);
            services.AddScoped<TService, TImplementation>();
            return services;
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="level">Ef日志级别</param>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            string connection, EfLogLevel level = EfLogLevel.Sql)
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService
        {
            EfConfig.LogLevel = level;
            return AddUnitOfWork<TService, TImplementation>(services, builder =>
            {
                ConfigConnection<TImplementation>(builder, connection);
            });
        }

        /// <summary>
        /// 配置连接字符串
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="builder"></param>
        /// <param name="connection"></param>
        private static void ConfigConnection<TImplementation>(DbContextOptionsBuilder builder, string connection)
            where TImplementation : UnitOfWorkBase
        {
            var type = typeof(TImplementation).BaseType;
            if (type == typeof(SqlServer.UnitOfWork))
            {
                builder.UseSqlServer(connection);
                return;
            }
            if (type == typeof(MySql.UnitOfWork))
            {
                builder.UseMySql(connection);
                return;
            }
            if (type == typeof(PgSql.UnitOfWork))
            {
                builder.UseNpgsql(connection);
                return;
            }
        }
    }
}
