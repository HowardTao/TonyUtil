using TonyUtil.Ui.Builders;

namespace TonyUtil.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat列表标题生成器
    /// </summary>
    public class ListTitleBuilder : TagBuilder {
        /// <summary>
        /// 初始化列表标题生成器
        /// </summary>
        public ListTitleBuilder() : base( "h3" ) {
            AddAttribute( "matLine" );
        }
    }
}