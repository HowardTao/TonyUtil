using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Styles;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
