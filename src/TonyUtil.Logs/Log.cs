using System;
using TonyUtil.Domains.Sessions;
using TonyUtil.Helpers;
using TonyUtil.Logs.Abstractions;
using TonyUtil.Logs.Contents;
using TonyUtil.Logs.Core;
using TonyUtil.Security;

namespace TonyUtil.Logs
{
    /// <summary>
    /// 日志操作
    /// </summary>
   public class Log:LogBase<LogContent>
    {
        /// <summary>
        /// 类名
        /// </summary>
        private readonly string _class;

        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="providerFactory">日志提供程序工厂</param>
        /// <param name="content">日志上下文</param>
        /// <param name="format">日志格式器</param>
        /// <param name="session">用户会话</param>
        public Log(ILogProviderFactory providerFactory,ILogContent content,ILogFormat format,ISession session) : base(providerFactory.Create("", format), content, session) { }

        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="content">日志上下文</param>
        /// <param name="session">用户会话</param>
        /// <param name="class">类名</param>
        public Log(ILogProvider provider, ILogContent content, ISession session,string @class) : base(provider, content, session)
        {
            _class = @class;
        }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        /// <returns></returns>
        protected override LogContent GetContent()
        {
            return new LogContent {Class = _class};
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="content"></param>
        protected override void Init(LogContent content)
        {
            base.Init(content);
            content.Tenant = Session.GetTenant();
            content.Application = Session.GetApplication();
            content.Operator = Session.GetFullName();
            content.Role = Session.GetRoleName();
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <returns></returns>
        public static ILog GetLog()
        {
            return GetLog(string.Empty);
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns></returns>
        public static ILog GetLog(object instance)
        {
            if (instance == null) return GetLog();
            var className = instance.GetType().ToString();
            return GetLog(className, className);

        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName"></param>
        /// <returns></returns>
        public static ILog GetLog(string logName)
        {
            return GetLog(logName, string.Empty);
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static ILog GetLog(string logName, string @class)
        {
            var providerFactory = GetLogProviderFactory();
            var format = getlog
        }


        private static ILogProviderFactory GetLogProviderFactory()
        {
            try
            {
                return Ioc.Create<ILogProviderFactory>();
            }
            catch 
            {
                //return new nlog
            }
        }

        private static ILogFormat GetLogFormat()
        {
            try
            {
                return Ioc.Create<ILogFormat>();
            }
            catch
            {

            }
        }
    }
}
