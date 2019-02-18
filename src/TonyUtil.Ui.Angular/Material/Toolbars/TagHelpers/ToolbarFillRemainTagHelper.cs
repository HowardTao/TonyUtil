using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Toolbars.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Toolbars.TagHelpers {
    /// <summary>
    /// 工具栏填充项
    /// </summary>
    [HtmlTargetElement( "util-toolbar-fill-remain",TagStructure = TagStructure.WithoutEndTag)]
    public class ToolbarFillRemainTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ToolbarFillRemainRender( new Config( context ) );
        }
    }
}