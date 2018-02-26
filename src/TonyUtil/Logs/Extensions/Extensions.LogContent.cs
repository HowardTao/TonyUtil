using System;
using System.Collections.Generic;
using System.Text;
using TonyUtil.Logs.Abstractions;

namespace TonyUtil.Logs.Extensions
{
    /// <summary>
    /// 日志扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public static void Append(this ILogContent content, StringBuilder result, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            result.Append("   ");
            result.Append(value);
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        /// <param name="content"></param>
        /// <param name="result"></param>
        /// <param name="value"></param>
        public static void AppendLine(this ILogContent content, StringBuilder result, string value)
        {
           content.Append(result,value);
            result.AppendLine();
        }

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="content"></param>
        /// <param name="value"></param>
        public static void Content(this ILogContent content, string value)
        {
            content.AppendLine(content.Content,value);
        }
    }
}
