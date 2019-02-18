using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Dialogs.Renders;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层操作
    /// </summary>
    [HtmlTargetElement( "util-dialog-actions" )]
    public class DialogActionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 对齐方式
        /// </summary>
        public Align Align { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogActionRender( new Config( context ) );
        }
    }
}