﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Panels.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;
namespace TonyUtil.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 面板标题
    /// </summary>
    [HtmlTargetElement( "util-panel-title" )]
    public class PanelTitleTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new PanelTitleRender( new Config( context ) );
        }
    }
}