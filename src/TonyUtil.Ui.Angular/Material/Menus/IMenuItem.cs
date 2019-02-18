using TonyUtil.Ui.Components;
using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Events;
using TonyUtil.Ui.Operations.Navigation;

namespace TonyUtil.Ui.Material.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    public interface IMenuItem : IComponent,ILabel,ISetIcon,IDisabled,ILink,IOnClick, IMenuId {
    }
}