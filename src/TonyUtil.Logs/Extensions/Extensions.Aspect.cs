using System.Collections.Generic;
using System.Linq;
using AspectCore.DynamicProxy.Parameters;
using TonyUtil.Helpers;

namespace TonyUtil.Logs.Extensions
{
    /// <summary>
    /// AOP扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 添加日志参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="log">操作日志</param>
        public static void AppendTo(this Parameter parameter, ILog log)
        {
            log.Params(parameter.ParameterInfo.ParameterType.FullName, parameter.Name, GetParameterValue(parameter));
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static string GetParameterValue(Parameter parameter)
        {
            if (!Reflection.IsGenericCollection(parameter.RawType)) return parameter.Value.SafeString();
            if (!(parameter.Value is IEnumerable<object> list)) return parameter.Value.SafeString();
            return list.Select(t => t.SafeString()).Join();
        }
    }
}
