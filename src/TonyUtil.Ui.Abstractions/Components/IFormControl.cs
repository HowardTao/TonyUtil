using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Bind;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Form;
using TonyUtil.Ui.Operations.Form.Validations;
using TonyUtil.Ui.Operations.Layouts;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 表单控件
    /// </summary>
    public interface IFormControl : IComponent,IName,IDisabled, IPlaceholder, IHint, IPrefix, ISuffix, IModel, 
        IRequired, IOnChange, IOnFocus, IOnBlur, IOnKeyup, IOnKeydown, IColspan, IStandalone,
        IBindName {
    }
}