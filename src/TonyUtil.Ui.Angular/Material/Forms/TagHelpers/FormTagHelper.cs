using Microsoft.AspNetCore.Razor.TagHelpers;
using TonyUtil.Ui.Angular.TagHelpers;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Forms.Renders;
using TonyUtil.Ui.Renders;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 表单
    /// </summary>
    [HtmlTargetElement( "util-form" )]
    public class FormTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 提交事件处理函数，范例：handle()
        /// </summary>
        public string OnSubmit { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormRender( new Config( context ) );
        }
    }
}