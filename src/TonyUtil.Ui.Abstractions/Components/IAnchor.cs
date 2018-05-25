using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Navigation;
using TonyUtil.Ui.Operations.Styles;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 链接
    /// </summary>
    public interface IAnchor : IComponent, ILink, IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
