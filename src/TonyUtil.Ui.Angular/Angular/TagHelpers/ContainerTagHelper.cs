using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.Renders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Angular.TagHelpers {
    /// <summary>
    /// ng-container容器
    /// </summary>
    [HtmlTargetElement( "util-container" )]
    public class ContainerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ContainerRender( new Config( context ) );
        }
    }
}