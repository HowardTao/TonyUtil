namespace TonyUtil.Datas.Queries
{
    /// <summary>
    /// 排序项
    /// </summary>
   public class OrderByItem
    {
        /// <summary>
        /// 排序属性
        /// </summary>
        public string  Name { get; }

        /// <summary>
        /// 是否降序
        /// </summary>
        public bool Desc { get; }

        /// <summary>
        /// 初始化排序项
        /// </summary>
        /// <param name="name">排序属性</param>
        /// <param name="desc">是否降序</param>
        public OrderByItem(string name, bool desc)
        {
            Name = name;
            Desc = desc;
        }

        /// <summary>
        /// 创建排序字符串
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            return Desc ? $"{Name} desc" : Name;
        }
    }
}
