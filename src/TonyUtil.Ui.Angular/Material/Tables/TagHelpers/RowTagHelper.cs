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
    /// 表格行定义，该标签应放在 util-table 中
    /// </summary>
    [HtmlTargetElement( "util-table-row", ParentTag = "util-table" )]
    public class RowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 显示列的集合，范例：['selectCheckbox','lineNumber', 'name','nickname','mobile']
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// 冻结表头，默认为true
        /// </summary>
        public bool StickyHeader { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if( shareConfig != null )
                shareConfig.AutoCreateRow = false;
        }
    }
}