using Microsoft.AspNetCore.Mvc.Rendering;
using TagBuilder = TonyUtil.Ui.Builders.TagBuilder;

namespace TonyUtil.Ui.Material.Cards.Builders {
    /// <summary>
    /// Mat卡片头像生成器
    /// </summary>
    public class CardAvatarBuilder : TagBuilder {
        /// <summary>
        /// 初始化卡片头像生成器
        /// </summary>
        public CardAvatarBuilder() : base( "img", TagRenderMode.SelfClosing ) {
            AddAttribute( "mat-card-avatar" );
        }
    }
}