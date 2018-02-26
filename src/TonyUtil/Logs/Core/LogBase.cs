using System;
using TonyUtil.Domains.Sessions;
using TonyUtil.Logs.Abstractions;

namespace TonyUtil.Logs.Core
{
    /// <summary>
    /// 日志操作
    /// </summary>
    /// <typeparam name="TContent">日志内容类型</typeparam>
   public abstract class LogBase<TContent>:ILog where TContent:class ,ILogContent
    {
        /// <summary>
        /// 日志内容
        /// </summary>
        private TContent _content;

        /// <summary>
        /// 日志内容
        /// </summary>
        private TContent LogContent => _content ?? (_content = GetContent());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="content">日志上下文</param>
        /// <param name="session">用户会话</param>
        protected LogBase(ILogProvider provider, ILogContent content, ISession session)
        {
            Provider = provider;
            Content = content;
            Session = session ?? Domains.Sessions.Session.Null;
        }

        /// <summary>
        /// 日志提供程序
        /// </summary>
        public ILogProvider Provider { get;}

        /// <summary>
        /// 日志上下文
        /// </summary>
        public ILogContent Content { get; }

        /// <summary>
        /// 用户会话
        /// </summary>
        public ISession Session { get; }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        /// <returns></returns>
        protected abstract TContent GetContent();

        public ILog Set<TContent1>(Action<TContent1> action) where TContent1 : ILogContent
        {
            throw new NotImplementedException();
        }

        public bool IsDebugEnabled { get; }
        public bool IsTraceEnabled { get; }
        public void Trace()
        {
            throw new NotImplementedException();
        }

        public void Trace(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug()
        {
            throw new NotImplementedException();
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Info()
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn()
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void Error()
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal()
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }
    }
}
