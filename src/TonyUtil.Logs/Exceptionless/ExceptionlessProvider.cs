﻿using System.Linq;
using Exceptionless;
using Microsoft.Extensions.Logging;
using el = Exceptionless;
using NLogs = NLog;
using TonyUtil.Logs.Abstractions;
using TonyUtil.Logs.Contents;
using TonyUtil.Logs.NLog;

namespace TonyUtil.Logs.Exceptionless
{
    /// <summary>
    /// Exceptionless日志提供程序
    /// </summary>
    public class ExceptionlessProvider:ILogProvider
    {
        /// <summary>
        /// NLog日志操作，用于控制日志级别是否启用
        /// </summary>
        private readonly NLogs.ILogger _logger;

        /// <summary>
        /// 客户端
        /// </summary>
        private readonly ExceptionlessClient _client;

        /// <summary>
        /// 行号
        /// </summary>
        private int _line;

        /// <summary>
        /// 初始化Exceptionless日志提供程序
        /// </summary>
        /// <param name="logName"></param>
        public ExceptionlessProvider(string logName)
        {
            _logger = NLogProvider.GetLogger(logName);
            _client = ExceptionlessClient.Default;
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName => _logger.Name;

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        public void WriteLog(LogLevel level, ILogContent content)
        {
            InitLine();
            var builder = CreateBuilder(level, content);
            SetUser(content);
            SetSource(builder,content);
            SetReferenceId(builder,content);
            AddProperties(builder,content as ILogConvert);
            builder.Submit();
        }

        private void InitLine()
        {
            _line = 1;
        }

        private EventBuilder CreateBuilder(LogLevel level, ILogContent content)
        {
            if (content.Exception != null) return _client.CreateException(content.Exception);
            return _client.CreateLog(GetMessage(content), ConvertTo(level));
        }

        /// <summary>
        /// 获取日志消息
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GetMessage(ILogContent content)
        {
            var caption = content as ICaption;
            if (caption != null && string.IsNullOrWhiteSpace(caption.Caption) == false) return caption.Caption;
            if (content.Content.Length > 0) return content.Content.ToString();
            return content.TraceId;
        }

        /// <summary>
        /// 转换日志等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private el.Logging.LogLevel ConvertTo(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return el.Logging.LogLevel.Trace;
                case LogLevel.Debug:
                    return el.Logging.LogLevel.Debug;
                case LogLevel.Information:
                    return el.Logging.LogLevel.Info;
                case LogLevel.Warning:
                    return el.Logging.LogLevel.Warn;
                case LogLevel.Error:
                    return el.Logging.LogLevel.Error;
                case LogLevel.Critical:
                    return el.Logging.LogLevel.Fatal;
                default:
                    return el.Logging.LogLevel.Off;
            }
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="content"></param>
        private void SetUser(ILogContent content)
        {
            if(string.IsNullOrWhiteSpace(content.UserId)) return;
            _client.Configuration.SetUserIdentity(content.UserId);
        }

        /// <summary>
        /// 设置来源
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="content"></param>
        private void SetSource(EventBuilder builder, ILogContent content)
        {
            if(string.IsNullOrWhiteSpace(content.Url)) return;
            builder.SetSource(content.Url);
        }

        /// <summary>
        /// 设置跟踪号
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="content"></param>
        private void SetReferenceId(EventBuilder builder, ILogContent content)
        {
            builder.SetReferenceId(content.TraceId);
        }

        /// <summary>
        /// 添加属性集合
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="content"></param>
        private void AddProperties(EventBuilder builder, ILogConvert content)
        {
            if(content==null) return;
            foreach (var parameter in content.To().OrderBy(t=>t.SortId))
            {
                if(string.IsNullOrWhiteSpace(parameter.Value.SafeString())) continue;
                builder.SetProperty($"{GetLine()}.{parameter.Text}", parameter.Value);
            }
        }

        /// <summary>
        /// 获取行号
        /// </summary>
        /// <returns></returns>
        private string GetLine()
        {
            return _line++.ToString().PadLeft(2, '0');
        }
    }
}
