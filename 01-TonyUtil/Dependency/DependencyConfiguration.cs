using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace TonyUtil.Dependency
{
    /// <summary>
    /// 依赖配置 TODO
    /// </summary>
   public class DependencyConfiguration
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// 依赖配置
        /// </summary>
        private readonly IConfig[] _configs;
        /// <summary>
        /// 容器生成器
        /// </summary>
        private ContainerBuilder _builder;
        /// <summary>
        /// 类型查找器
        /// </summary>
        private IFind _finder;
        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;
    }
}
