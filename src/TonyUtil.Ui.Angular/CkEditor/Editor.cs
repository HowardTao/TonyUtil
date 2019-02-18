using TonyUtil.Ui.CkEditor.Renders;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.CkEditor {
    /// <summary>
    /// 富文本框编辑器
    /// </summary>
    public class Editor : ComponentBase, IEditor {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new EditorRender( OptionConfig );
        }
    }
}