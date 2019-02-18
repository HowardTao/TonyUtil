using TonyUtil.Ui.Components;
using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Datas;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Form;
using TonyUtil.Ui.Operations.Layouts;

namespace TonyUtil.Ui.Material.Lists {
    /// <summary>
    /// 选择列表
    /// </summary>
    public interface ISelectList : IComponent, IName, IDisabled, IModel, IOnChange, IColspan, IUrl, IDataSource, IItem,ILabel {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        ISelectList Enum<TEnum>();
    }
}