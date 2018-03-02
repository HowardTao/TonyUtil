using AspectCore.DynamicProxy;
using TonyUtil.Aspects.Base;

namespace TonyUtil.Logs.Aspects
{
   public abstract class LogAttributeBase: InterceptorBase
    {

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        protected  virtual bool Enabled(ILog log)
        {
            return true;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        protected abstract void WriteLog(ILog log);

        /// <summary>
        /// 获取方法名
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetMethodName(AspectContext context)
        {
            return $"{context.ServiceMethod.DeclaringType.FullName}.{context.ServiceMethod.Name}";
        }

        private void ExecuteBefore(ILog log, AspectContext context, string methodName)
        {
            
        }

        private void ExecuteAfter(ILog log, AspectContext context, string methodName)
        {
            
        }

    }
}
