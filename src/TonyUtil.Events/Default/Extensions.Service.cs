using Microsoft.Extensions.DependencyInjection;
using TonyUtil.Events.Handlers;

namespace TonyUtil.Events.Default
{
    /// <summary>
    /// 事件总线扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 注册事件总线服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            return services.AddSingleton<IEventHandlerManager, EventHandlerManager>()
                .AddSingleton<IEventBus, EventBus>();
        }
    }
}
