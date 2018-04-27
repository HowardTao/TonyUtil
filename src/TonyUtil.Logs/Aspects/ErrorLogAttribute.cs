using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using TonyUtil.Aspects.Base;

namespace TonyUtil.Logs.Aspects
{
    /// <summary>
    /// 调试日志
    /// </summary>
   public class ErrorLogAttribute : InterceptorBase
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var methodName = GetMethodName(context);
            var log = Log.GetLog
        }

        /// <summary>
        /// 获取方法名
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetMethodName(AspectContext context)
        {
            return $"{context.ServiceMethod.DeclaringType.FullName}.{context.ServiceMethod.Name}";
        }
    }
}
