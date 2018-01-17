﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TonyUtil.Helpers;

namespace TonyUtil.Dependency
{
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    public class Container:IContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        private Autofac.IContainer _container;

        /// <summary>
        /// 释放容器
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public List<T> CreateList<T>(string name = null)
        {
            var result = CreateList(typeof(T), name);
            return result == null ? new List<T>() : ((IEnumerable<T>) result).ToList();
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public object CreateList(Type type, string name = null)
        {
            var serviceType = typeof(IEnumerable<>).MakeGenericType(type);
            return Create(serviceType, name);
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public T Create<T>(string name = null)
        {
            return (T) Create(typeof(T), name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public object Create(Type type, string name = null)
        {
            return Web.HttpContext?.RequestServices != null
                ? GetServiceFromHttpContext(type, name)
                : GetService(type, name);
        }

        /// <summary>
        /// 从HttpContext获取服务
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private object GetServiceFromHttpContext(Type type, string name)
        {
            var serviceProvider = Web.HttpContext.RequestServices;
            if (name == null) return serviceProvider.GetService(type);
            var context = serviceProvider.GetService<IComponentContext>();
            return context.ResolveNamed(name, type);
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private object GetService(Type type, string name)
        {
            return name == null ? _container.Resolve(type) : _container.ResolveNamed(name, type);
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        /// <returns></returns>
        public IScope BeginScope()
        {
            return new Scope(_container.BeginLifetimeScope());
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public void Register(params IConfig[] configs)
        {
             Register(null, null, configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public IServiceProvider Register(IServiceCollection services, params IConfig[] configs)
        {
            return Register(services, null, configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public IServiceProvider Register(IServiceCollection services,Action<ContainerBuilder> actionBefore, params IConfig[] configs)
        {
            var builder = CreateBuilder(services, actionBefore, configs);
            _container = builder.Build();
            return new AutofacServiceProvider(_container);
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services, Action<ContainerBuilder> actionBefore,
            params IConfig[] configs)
        {
            var builder = new ContainerBuilder();
            actionBefore?.Invoke(builder);
            foreach (var config in configs)
            {
                builder.RegisterModule(config);
            }
            if (services != null)
            {
                builder.Populate(services);
            }
            return builder;
        }
    }
}
