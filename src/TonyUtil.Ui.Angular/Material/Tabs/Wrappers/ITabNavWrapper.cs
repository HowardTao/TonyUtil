using System;

namespace TonyUtil.Ui.Material.Tabs.Wrappers {
    /// <summary>
    /// 导航选项卡包装器
    /// </summary>
    public interface ITabNavWrapper : IDisposable {
        /// <summary>
        /// 选项卡
        /// </summary>
        ITabLink Tab();
    }
}