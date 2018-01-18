namespace TonyUtil.Domains
{
    /// <summary>
    /// 聚合根
    /// </summary>
   public interface IAggregateRoot : IEntity, IVersion { }

    public interface IAggregateRoot<out TKey> : IEntity<TKey>, IAggregateRoot { }
}
