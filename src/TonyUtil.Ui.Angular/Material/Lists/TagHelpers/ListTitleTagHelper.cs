using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Lists.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 列表标题，该标签应放到 util-list-item 中
    /// </summary>
    [HtmlTargetElement( "util-list-title" )]
    public class ListTitleTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ListTitleRender( new Config( context ) );
        }
    }
}