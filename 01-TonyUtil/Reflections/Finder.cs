using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TonyUtil.Reflections
{
    /// <summary>
    /// 类型查找器
    /// </summary>
    public class Finder:IFind
    {

        /// <summary>
        /// 跳过的程序集
        /// </summary>
        private const string SkipAssemblies = "^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        /// <summary>
        /// 从当前应用程序域获取程序集列表
        /// </summary>
        /// <returns></returns>
        private List<Assembly> GetAssembliesFromCurrentAppDomain()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => Match(assembly));
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 程序集是否匹配
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private bool Match(Assembly assembly)
        {
            return !Regex.IsMatch(assembly.FullName, SkipAssemblies, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 程序集是否匹配
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private bool Match(AssemblyName assemblyName)
        {
            return !Regex.IsMatch(assemblyName.FullName, SkipAssemblies, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 获取类型列表
        /// </summary>
        /// <param name="findType"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private List<Type> GetTypes(Type findType, Assembly assembly)
        {
            var result = new List<Type>();
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException)
            {
                return result;
            }
            if (types == null) return result;
            foreach (var type in types)
            {
                AddType(result,findType,type);
            }
            return result;
        }

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="result"></param>
        /// <param name="findType"></param>
        /// <param name="type"></param>
        private void AddType(List<Type> result, Type findType, Type type)
        {
            if (type.IsInterface || type.IsAbstract) return;
            if (findType.IsAssignableFrom(type) == false && MatchGeneric(findType, type) == false) return;
            result.Add(type);
        }

        /// <summary>
        /// 泛型匹配
        /// </summary>
        /// <param name="findType"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool MatchGeneric(Type findType, Type type)
        {
            if (findType.IsGenericTypeDefinition == false) return false;
            var definition = findType.GetGenericTypeDefinition();
            foreach (var implementedInterface in type.FindInterfaces((filter,criteria)=>true,null))
            {
                if(implementedInterface.IsGenericTypeDefinition==false) continue;
                return definition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
            }
            return false;
        }

        /// <summary>
        /// 加载程序集到当前应用程序域
        /// </summary>
        /// <param name="path">目录绝对路径</param>
        protected void LoadAssemblies(string path)
        {
            foreach (var file in Directory.GetFiles(path,"*.dll"))
            {
                var assemblyName = AssemblyName.GetAssemblyName(file);
                if (Match(assemblyName)) AppDomain.CurrentDomain.Load(assemblyName);
            }
        }

        /// <summary>
        /// 获取程序集列表
        /// </summary>
        /// <returns></returns>
        public virtual List<Assembly> GetAssemblies()
        {
            return GetAssembliesFromCurrentAppDomain();
        }

        /// <summary>
        /// 查询类型列表
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        /// <returns></returns>
        public List<Type> Find<T>(List<Assembly> assemblies = null)
        {
            return Find(typeof(T), assemblies);
        }

        /// <summary>
        /// 查询类型列表
        /// </summary>
        /// <param name="findType">查找类型</param>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        /// <returns></returns>
        public List<Type> Find(Type findType, List<Assembly> assemblies = null)
        {
            assemblies = assemblies ?? GetAssemblies();
            var result = new List<Type>();
            foreach (var assembly in assemblies)
            {
                result.AddRange(GetTypes(findType,assembly));
            }
            return result.Distinct().ToList();
        }
    }
}
