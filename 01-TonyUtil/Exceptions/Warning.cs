﻿using System;
using System.Collections;
using System.Text;
using Microsoft.Extensions.Logging;
using TonyUtil.Properties;

namespace TonyUtil.Exceptions
{
    /// <summary>
    /// 应用程序异常
    /// </summary>
   public class Warning:Exception
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// 错误码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        public Warning (string message) : this(message, "") { }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="exception">异常</param>
        public Warning(Exception exception) : this("", "", exception) { }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        public Warning (string message,string code) : this(message, code, null) { }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        /// <param name="exception">异常</param>
        public Warning(string message, string code, Exception exception) : base(message ?? "", exception)
        {
            Code = code;
            _message = GetMessage();
        }

        /// <summary>
        /// 获取错误消息
        /// </summary>
        /// <returns></returns>
        private string GetMessage()
        {
            var result = new StringBuilder();
            AppendSelfMessage(result);
            AppendInnerMessage(result,InnerException);
            return result.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// 添加外层异常消息
        /// </summary>
        /// <param name="result"></param>
        private void AppendSelfMessage(StringBuilder result)
        {
            if (string.IsNullOrWhiteSpace(base.Message)) return ;
            result.AppendLine(base.Message);
        }

        /// <summary>
        /// 添加内部异常消息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="exception"></param>
        private void AppendInnerMessage(StringBuilder result, Exception exception)
        {
            if (exception == null) return;
            if (exception is Warning)
            {
                result.AppendLine(exception.Message);
                return;
            }
            result.AppendLine(exception.Message);
            AppendData(result,exception);
            AppendInnerMessage(result,exception.InnerException);
        }

        /// <summary>
        /// 添加额外数据
        /// </summary>
        /// <param name="result"></param>
        /// <param name="exception"></param>
        private void AppendData(StringBuilder result, Exception exception)
        {
            foreach (DictionaryEntry data in exception.Data)
            {
                result.AppendFormat("{0}:{1}{2}", data.Key, data.Value, Environment.NewLine);
            }
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        public override string Message
        {
            get
            {
                if (Data.Count == 0) return _message;
                var result = new StringBuilder();
                result.AppendLine(_message);
                AppendData(result,this);
                return result.ToString();
            }
        }

        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        public override string StackTrace
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(base.StackTrace))  return base.StackTrace;
                if (InnerException == null) return string.Empty;
                return InnerException.StackTrace;
            }
        }

        /// <summary>
        /// 获取友情提示
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns></returns>
        public string GetPrompt(LogLevel level)
        {
            if (level == LogLevel.Error) return R.SystemError;
            return Message;
        }
    }
}
