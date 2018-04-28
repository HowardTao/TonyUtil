﻿using System;
using TonyUtil.Exceptions;
using TonyUtil.Logs.Contents;

namespace TonyUtil.Logs.Extensions
{
    /// <summary>
    /// 日志扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 设置业务编号
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="businessId">业务编号</param>
        /// <returns></returns>
        public static ILog BusinessId(this ILog log, string businessId)
        {
            return log.Set<LogContent>(content =>
            {
                if (!string.IsNullOrWhiteSpace(content.BusinessId)) content.BusinessId += ",";
                content.BusinessId += businessId;
            });
        }

        /// <summary>
        /// 设置模块
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="module">模块</param>
        /// <returns></returns>
        public static ILog Module(this ILog log, string module)
        {
            return log.Set<LogContent>(content => content.Module = module);
        }

        /// <summary>
        /// 设置类名
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="class">类名</param>
        /// <returns></returns>
        public static ILog Class(this ILog log, string @class)
        {
            return log.Set<LogContent>(content => content.Class = @class);
        }

        /// <summary>
        /// 设置方法
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="method">方法</param>
        /// <returns></returns>
        public static ILog Method(this ILog log, string method)
        {
            return log.Set<LogContent>(content => content.Method = method);
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="type">参数类型</param>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public static ILog Params(this ILog log, string type, string name, string value)
        {
            return log.Set<LogContent>(content => content.AppendLine(content.Params,
                $"{LogResource.ParameterType}: {type}, {LogResource.ParameterName}: {name}, {LogResource.ParameterValue}: {value}。"));
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="caption">标题</param>
        public static ILog Caption(this ILog log, string caption)
        {
            return log.Set<LogContent>(content => content.Caption = caption);
        }

        /// <summary>
        /// 设置Sql语句
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="value">值</param>
        public static ILog Sql(this ILog log, string value)
        {
            return log.Set<LogContent>(content => content.AppendLine(content.Sql, value));
        }

        /// <summary>
        /// 设置Sql参数
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="value">值</param>
        public static ILog SqlParams(this ILog log, string value)
        {
            return log.Set<LogContent>(content => content.AppendLine(content.SqlParams, value));
        }

        /// <summary>
        /// 设置异常
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="exception">异常</param>
        /// <param name="errorCode">错误码</param>
        public static ILog Exception(this ILog log, Exception exception, string errorCode = "")
        {
            if (exception == null)
                return log;
            return Exception(log, new Warning("", errorCode, exception));
        }

        /// <summary>
        /// 设置异常
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="exception">异常</param>
        public static ILog Exception(this ILog log, Warning exception)
        {
            if (exception == null)
                return log;
            return log.Set<LogContent>(content => {
                content.ErrorCode = exception.Code;
                content.Exception = exception;
            });
        }
    }
}
