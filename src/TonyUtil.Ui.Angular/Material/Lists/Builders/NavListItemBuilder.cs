using TonyUtil.Ui.Builders;

namespace TonyUtil.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat导航列表项生成器
    /// </summary>
    public class NavListItemBuilder : TagBuilder {
        /// <summary>
        /// 初始化导航列表项生成器
        /// </summary>
        public NavListItemBuilder() : base( "a" ) {
            AddAttribute( "mat-list-item" );
        }
    }
}