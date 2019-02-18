using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.SideNavs.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏导航容器
    /// </summary>
    [HtmlTargetElement( "util-sidenav-container" )]
    public class SideNavContainerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 全屏
        /// </summary>
        public bool Fullscreen { get; set; }
        /// <summary>
        /// 自动调整大小
        /// </summary>
        public bool AutoSize { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SideNavContainerRender( new Config( context ) );
        }
    }
}