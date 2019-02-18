using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Lists.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表
    /// </summary>
    [HtmlTargetElement( "util-nav-list" )]
    public class NavListTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 紧凑模式，列表内容间距变小
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListRender( new Config( context ) );
        }
    }
}