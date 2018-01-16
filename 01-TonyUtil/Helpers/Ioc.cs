﻿using System;
using System.Collections.Generic;
using System.Linq;
using TonyUtil.Dependency;

namespace TonyUtil.Helpers
{
    /// <summary>
    /// 容器
    /// </summary>
   public static class Ioc
    {
        /// <summary>
        /// 默认容器
        /// </summary>
        internal static readonly Container DefaultContainer = new Container();

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public static IContainer CreateContainer(params IConfig[] configs)
        {
            var container = new Container();
            container.Register(null, builder => builder.EnableAop(), configs);
            return container;
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public static List<T> CreateList<T>(string name = null)
        {
            return DefaultContainer.CreateList<T>(name);
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public static List<TResult> CreateList<TResult>(Type type, string name = null)
        {
            return ((IEnumerable<TResult>)DefaultContainer.CreateList(type, name)).ToList();
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public static T Create<T>(string name = null)
        {
            return DefaultContainer.Create<T>(name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public static TResult Create<TResult>(Type type, string name = null)
        {
            return (TResult) DefaultContainer.Create(type, name);
        }


    }
}
