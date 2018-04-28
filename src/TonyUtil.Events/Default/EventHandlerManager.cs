using System.Collections.Generic;
using TonyUtil.Events.Handlers;
using TonyUtil.Helpers;

namespace TonyUtil.Events.Default
{
    /// <summary>
    /// 事件处理器服务
    /// </summary>
   public class EventHandlerManager:IEventHandlerManager
    {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        public List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent
        {
            return Ioc.CreateList<IEventHandler<TEvent>>();
        }
    }
}
