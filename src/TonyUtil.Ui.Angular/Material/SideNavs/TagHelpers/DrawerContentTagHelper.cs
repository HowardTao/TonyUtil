using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.SideNavs.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏内容区域
    /// </summary>
    [HtmlTargetElement( "util-drawer-content" )]
    public class DrawerContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DrawerContentRender( new Config( context ) );
        }
    }
}