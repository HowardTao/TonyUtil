using Microsoft.AspNetCore.Mvc.Rendering;

namespace TonyUtil.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat列表头像生成器
    /// </summary>
    public class ListAvatarBuilder : Ui.Builders.TagBuilder {
        /// <summary>
        /// 初始化列表头像生成器
        /// </summary>
        public ListAvatarBuilder() : base( "img", TagRenderMode.SelfClosing ) {
            AddAttribute( "matListAvatar" );
        }
    }
}