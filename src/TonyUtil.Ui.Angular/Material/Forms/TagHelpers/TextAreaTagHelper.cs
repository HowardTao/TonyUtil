﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Material.Forms.Configs;
using TonyUtil.Ui.Material.Forms.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 多行文本框
    /// </summary>
    [HtmlTargetElement( "util-textarea" )]
    public class TextAreaTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 是否显示清除按钮
        /// </summary>
        public bool ShowClearButton { get; set; }
        /// <summary>
        /// 只读
        /// </summary>
        public bool Readonly { get; set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public string MinLength { get; set; }
        /// <summary>
        /// 最小长度错误消息
        /// </summary>
        public string MinLengthMessage { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public string MaxLength { get; set; }
        /// <summary>
        /// 最小行数
        /// </summary>
        public string MinRows { get; set; }
        /// <summary>
        /// 最大行数
        /// </summary>
        public string MaxRows { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TextBoxConfig( context ) {IsTextArea = true};
            return new TextBoxRender( config );
        }
    }
}
