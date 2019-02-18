using System;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Operations;

namespace TonyUtil.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡
    /// </summary>
    public interface ITab : IContainer<IDisposable>, ILabel, ISetIcon,IDisabled {
    }
}