using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.Renders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Angular.TagHelpers {
    /// <summary>
    /// router-outlet路由出口
    /// </summary>
    [HtmlTargetElement( "util-router-outlet" )]
    public class RouterOutletTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RouterOutletRender( new Config( context ) );
        }
    }
}