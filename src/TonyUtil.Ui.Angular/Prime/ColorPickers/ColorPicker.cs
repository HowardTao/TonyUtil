using TonyUtil.Ui.Components;
using TonyUtil.Ui.Prime.ColorPickers.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Prime.ColorPickers {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public class ColorPicker : ComponentBase, IColorPicker {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new ColorPickerRender( OptionConfig );
        }
    }
}