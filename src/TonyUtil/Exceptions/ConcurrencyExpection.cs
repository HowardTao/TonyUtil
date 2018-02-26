using System;
using TonyUtil.Properties;

namespace TonyUtil.Exceptions
{
   public class ConcurrencyExpection:Warning
    {

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        public ConcurrencyExpection() : this("") { }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        public ConcurrencyExpection(string message) : this(message, "")
        {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="exception">异常</param>
        public ConcurrencyExpection(Exception exception) : this("","",exception)
        {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="exception">异常</param>
        public ConcurrencyExpection(string message,Exception exception) : this(message, "", exception) { }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        public ConcurrencyExpection(string message, string code) : this(message,code,null)
        {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        /// <param name="exception">异常</param>
        public ConcurrencyExpection(string message, string code, Exception exception) : base(
            "并发异常：" + LibraryResource.ConcurrencyExceptionMessage + Environment.NewLine + message, code, exception)
        {
        }
    }
}
