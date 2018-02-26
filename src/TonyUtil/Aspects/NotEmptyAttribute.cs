using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;

namespace TonyUtil.Aspects
{
    /// <summary>
    /// 验证不能为空
    /// </summary>
   public class NotEmptyAttribute:ParameterInterceptorAttribute
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (string.IsNullOrWhiteSpace(context.Parameter.Value.SafeString()))
                throw new ArgumentNullException(context.Parameter.Name);
           return next(context);
        }
    }
}
