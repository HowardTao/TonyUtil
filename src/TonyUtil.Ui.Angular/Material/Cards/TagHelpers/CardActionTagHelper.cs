using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Cards.Renders;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片操作
    /// </summary>
    [HtmlTargetElement( "util-card-actions" )]
    public class CardActionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 对齐方式
        /// </summary>
        public XPosition Align { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardActionRender( new Config( context ) );
        }
    }
}