using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Bind;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Form;
using TonyUtil.Ui.Operations.Form.Validations;
using TonyUtil.Ui.Operations.Layouts;
using TonyUtil.Ui.Operations.Styles;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 滑动开关
    /// </summary>
    public interface ISlideToggle : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IColor, IColspan,
        IStandalone, IBindName {
    }
}