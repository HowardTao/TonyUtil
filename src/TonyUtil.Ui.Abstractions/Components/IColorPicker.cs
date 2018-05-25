using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Bind;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Form;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public interface IColorPicker : IComponent, IName, IDisabled, IModel, IOnChange,
        IStandalone, IBindName {
    }
}