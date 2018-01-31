using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Queries
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParameter:Pager,IQueryParameter
    {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescription()
        {
            base.AddDescription();
            AddDescription("Keyword",Keyword);
        }
    }
}
