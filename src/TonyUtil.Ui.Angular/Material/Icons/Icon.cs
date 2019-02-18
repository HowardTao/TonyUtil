using TonyUtil.Ui.Components;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Icons.Configs;
using TonyUtil.Ui.Material.Icons.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Icons {
    /// <summary>
    /// 图标
    /// </summary>
    public class Icon : ComponentBase, IIcon {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new IconRender( OptionConfig );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new IconConfig();
        }
    }
}
