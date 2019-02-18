using Microsoft.AspNetCore.Mvc.Rendering;
using TagBuilder = TonyUtil.Ui.Builders.TagBuilder;

namespace TonyUtil.Ui.Material.Cards.Builders {
    /// <summary>
    /// Mat卡片图片生成器
    /// </summary>
    public class CardImageBuilder : TagBuilder {
        /// <summary>
        /// 初始化卡片图片生成器
        /// </summary>
        public CardImageBuilder() : base( "img",TagRenderMode.SelfClosing ) {
            AddAttribute( "mat-card-image" );
        }
    }
}