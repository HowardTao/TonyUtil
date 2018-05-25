using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Bind;
using TonyUtil.Ui.Operations.Datas;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Form;
using TonyUtil.Ui.Operations.Form.Validations;
using TonyUtil.Ui.Operations.Layouts;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 单选框
    /// </summary>
    public interface IRadio : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IUrl, IDataSource, IItem, IColspan,
        IStandalone, IBindName {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        IRadio Enum<TEnum>();
    }
}
