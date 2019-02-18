using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Extensions;
using TonyUtil.Ui.Material.Tables.Configs;
using TonyUtil.Ui.Material.Tables.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格列头定义，该标签应放在 util-table-column 中
    /// </summary>
    [HtmlTargetElement( "util-table-header-cell", ParentTag = "util-table-column" )]
    public class HeaderCellTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 启用排序
        /// </summary>
        public bool Sort { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new HeaderCellRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<ColumnShareConfig>( ColumnConfig.ColumnShareKey );
            if( shareConfig != null )
                shareConfig.AutoCreateHeaderCell = false;
        }
    }
}