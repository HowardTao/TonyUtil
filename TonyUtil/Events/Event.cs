using System;
using System.Text;

namespace TonyUtil.Events
{
    /// <summary>
    /// 事件
    /// </summary>
   public class Event:IEvent
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        public Event()
        {
            Id = Guid.NewGuid().ToString();
            Time = DateTime.Now;
        }

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"事件标识：{Id}");
            result.AppendLine($"事件时间：{Time.ToMillisecondString()}");
            result.Append($"事件数据：{Helpers.Json.ToJson(this)}");
            return result.ToString();
        }
    }
}
