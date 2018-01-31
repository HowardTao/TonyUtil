using TonyUtil.Dependency;
using TonyUtil.Domains;

namespace TonyUtil.Datas.Persistence
{
    /// <summary>
    /// 持久化对象
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
   public interface IPersistentObject<out TKey>:IKey<TKey>,IScopeDependency,IVersion
    {
    }
}
