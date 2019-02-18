using TonyUtil.Ui.Components;
using TonyUtil.Ui.Material.Buttons.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Buttons {
    /// <summary>
    /// 链接
    /// </summary>
    public class Anchor : ComponentBase, IAnchor {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new AnchorRender( OptionConfig );
        }
    }
}