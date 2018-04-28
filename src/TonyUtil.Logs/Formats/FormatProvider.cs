using System;
using TonyUtil.Logs.Abstractions;

namespace TonyUtil.Logs.Formats
{
    /// <summary>
    /// 日志格式化提供程序
    /// </summary>
   public class FormatProvider:IFormatProvider,ICustomFormatter
    {
        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 初始化日志格式化提供程序
        /// </summary>
        /// <param name="format"></param>
        public FormatProvider(ILogFormat format)
        {
            _format = format ?? throw new ArgumentNullException(nameof(format));
        }

        /// <summary>
        /// 获取格式化器
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is ILogContent content)) return string.Empty;
            return _format.Format(content);
        }
    }
}
