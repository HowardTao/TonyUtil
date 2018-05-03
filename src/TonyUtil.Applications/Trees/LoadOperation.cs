namespace TonyUtil.Applications.Trees
{
    public enum LoadOperation
    {
        /// <summary>
        /// 初次加载
        /// </summary>
        FirstLoad = 1,

        /// <summary>
        /// 加载子节点
        /// </summary>
        LoadChild = 2,

        /// <summary>
        /// 搜索
        /// </summary>
        Search = 3
    }
}
