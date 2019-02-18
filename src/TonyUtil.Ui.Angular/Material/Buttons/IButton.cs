using System;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Operations.Navigation;

namespace TonyUtil.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IComponent, IContainer<IDisposable>, Components.IButton, IMenuId {
    }
}