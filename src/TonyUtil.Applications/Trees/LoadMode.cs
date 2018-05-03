namespace TonyUtil.Applications.Trees
{
    public enum LoadMode
    {
        /// <summary>
        /// 同步
        /// </summary>
        Sync,
        /// <summary>
        /// 异步
        /// </summary>
        Async,
        /// <summary>
        /// 根节点异步加载，下级节点一次性加载
        /// </summary>
        OnlyRootAsync
    }
}
