﻿using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using TonyUtil.Aspects.Base;
using TonyUtil.Logs.Extensions;

namespace TonyUtil.Logs.Aspects
{
    /// <summary>
    /// 日志操作
    /// </summary>
   public abstract class LogAttributeBase: InterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var methodName = GetMethodName(context);
            var log = Log.GetLog(methodName);
            if (!Enabled(log)) return;
            ExecuteBefore(log,context,methodName);
            await next(context);
            ExecuteAfter(log,context,methodName);
        }

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

        /// <summary>
        /// 执行前
        /// </summary>
        private void ExecuteBefore(ILog log, AspectContext context, string methodName)
        {
            log.Caption($"{context.ServiceMethod.Name}方法执行前")
                .Class(context.ServiceMethod.DeclaringType.FullName)
                .Method(methodName);
            foreach (var parameter in context.GetParameters())
                parameter.AppendTo(log);
            WriteLog(log);
        }

        /// <summary>
        /// 执行后
        /// </summary>
        private void ExecuteAfter(ILog log, AspectContext context, string methodName)
        {
            var parameter = context.GetReturnParameter();
            log.Caption($"{context.ServiceMethod.Name}方法执行后")
                .Method(methodName)
                .Content($"返回类型: {parameter.ParameterInfo.ParameterType.FullName},返回值: {parameter.Value.SafeString()}");
            WriteLog(log);
        }

    }
}
