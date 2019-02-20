﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Enums;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Lists.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表图标，该标签应放到 util-nav-list-item 中
    /// </summary>
    [HtmlTargetElement( "util-nav-list-icon",TagStructure = TagStructure.WithoutEndTag)]
    public class NavListIconTagHelper : AngularTagHelperBase {
        /// <summary>
        /// Material图标
        /// </summary>
        public MaterialIcon MaterialIcon { get; set; }
        /// <summary>
        /// Material图标绑定
        /// </summary>
        public string BindMaterialIcon { get; set; }
        /// <summary>
        /// Font Awesome图标
        /// </summary>
        public FontAwesomeIcon FontAwesomeIcon { get; set; }
        /// <summary>
        /// Font Awesome图标绑定
        /// </summary>
        public string BindFontAwesomeIcon { get; set; }
        /// <summary>
        /// 图标大小
        /// </summary>
        public IconSize Size { get; set; }
        /// <summary>
        /// 图标位置
        /// </summary>
        public XPosition Position { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListIconRender( new Config( context ) );
        }
    }
}