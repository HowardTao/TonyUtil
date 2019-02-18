using System.IO;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Material.Tabs.Renders;
using TonyUtil.Ui.Material.Tabs.Wrappers;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡组
    /// </summary>
    public class TabGroup : ContainerBase<ITabGroupWrapper>, ITabGroup {
        /// <summary>
        /// 初始化选项卡组
        /// </summary>
        /// <param name="writer">流写入器</param>
        public TabGroup( TextWriter writer ) : base( writer ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabGroupRender( OptionConfig );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override ITabGroupWrapper GetWrapper() {
            return new TabGroupWrapper( this );
        }
    }
}