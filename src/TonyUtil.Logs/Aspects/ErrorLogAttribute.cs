using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using TonyUtil.Aspects.Base;
using TonyUtil.Logs.Extensions;

namespace TonyUtil.Logs.Aspects
{
    /// <summary>
    /// 调试日志
    /// </summary>
   public class ErrorLogAttribute : InterceptorBase
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var methodName = GetMethodName(context);
            var log = Log.GetLog(methodName);
            try
            {
                await next(context);
            }
            catch (System.Exception ex)
            {
                log.Class(context.ServiceMethod.DeclaringType.FullName).Method(methodName).Exception(ex);
                foreach (var parameter in context.GetParameters())
                {
                    parameter.AppendTo(log);
                }
                throw;
            }
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
