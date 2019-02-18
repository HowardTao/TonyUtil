using System.IO;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Material.Tabs.Renders;
using TonyUtil.Ui.Material.Tabs.Wrappers;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Tabs {
    /// <summary>
    /// 导航选项卡
    /// </summary>
    public class TabNav : ContainerBase<ITabNavWrapper>, ITabNav {
        /// <summary>
        /// 初始化导航选项卡
        /// </summary>
        /// <param name="writer">流写入器</param>
        public TabNav( TextWriter writer ) : base( writer ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabNavRender( OptionConfig );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override ITabNavWrapper GetWrapper() {
            return new TabNavWrapper( this );
        }
    }
}