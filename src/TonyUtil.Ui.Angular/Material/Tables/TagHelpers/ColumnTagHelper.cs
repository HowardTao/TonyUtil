﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Extensions;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Tables.Configs;
using TonyUtil.Ui.Material.Tables.Renders;
using TonyUtil.Ui.Material.Tables.Resolvers;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格列定义，该标签应放在 util-table 中
    /// </summary>
    [HtmlTargetElement( "util-table-column", ParentTag = "util-table" )]
    public class ColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ColumnConfig _config;

        /// <summary>
        /// 初始化表格列定义
        /// </summary>
        public ColumnTagHelper() {
            _config = new ColumnConfig();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 表格列类型
        /// </summary>
        public TableColumnType Type { get; set; }
        /// <summary>
        /// 日期格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// 启用排序
        /// </summary>
        public bool Sort { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            _config.Content = context.Content;
            return new ColumnRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config.Load( context, output );
            _config.InitShare();
            ResolveExpression();
            AddColumnToParent();
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            ColumnExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 把列添加到表格容器
        /// </summary>
        private void AddColumnToParent() {
            var shareConfig = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            shareConfig?.Columns.Add( GetColumn() );
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        private string GetColumn() {
            if( _config.Context.GetValueFromAttributes<TableColumnType?>( UiConst.Type ) == TableColumnType.Checkbox )
                return "selectCheckbox";
            if( _config.Context.GetValueFromAttributes<TableColumnType?>( UiConst.Type ) == TableColumnType.LineNumber )
                return "lineNumber";
            return _config.GetValue<string>( UiConst.Column );
        }
    }
}