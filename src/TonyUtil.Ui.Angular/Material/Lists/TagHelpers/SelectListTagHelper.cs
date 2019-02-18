using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Forms.Configs;
using TonyUtil.Ui.Material.Lists.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 选择列表
    /// </summary>
    [HtmlTargetElement( "util-select-list" )]
    public class SelectListTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DatasSource { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 复选框位置
        /// </summary>
        public XPosition CheckboxPosition { get; set; }
        /// <summary>
        /// 变更事件
        /// </summary>
        public string OnChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new SelectConfig( context );
            if( config.Contains( UiConst.DataSource ) || config.Contains( UiConst.Url ) )
                return new SelectListWrapperRender( config );
            return new SelectListRender( config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            context.Items[MaterialConst.CheckboxPosition] = context.AllAttributes[MaterialConst.CheckboxPosition];
        }
    }
}