using TonyUtil.Ui.Builders;

namespace TonyUtil.Ui.Material.Dialogs.Builders {
    /// <summary>
    /// Mat弹出层标题生成器
    /// </summary>
    public class DialogTitleBuilder : TagBuilder {
        /// <summary>
        /// 初始化弹出层标题生成器
        /// </summary>
        public DialogTitleBuilder() : base( "h2" ) {
            AddAttribute( "mat-dialog-title" );
        }
    }
}