using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Tabs.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Tabs.TagHelpers {
    /// <summary>
    /// 选项卡组
    /// </summary>
    [HtmlTargetElement( "util-tabs" )]
    public class TabGroupTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 固定高度，单位：px
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// 动态高度
        /// </summary>
        public bool DynamicHeight { get; set; }
        /// <summary>
        /// 拉伸选项卡
        /// </summary>
        public bool Stretch { get; set; }
        /// <summary>
        /// 索引表达式
        /// </summary>
        public string SelectedIndex { get; set; }
        /// <summary>
        /// 选项卡位置
        /// </summary>
        public YPosition HeaderPosition { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabGroupRender( new Config( context ) );
        }
    }
}