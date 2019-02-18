using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Menus.Datas;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Menus.Configs {
    /// <summary>
    /// 菜单配置
    /// </summary>
    public class MenuConfig : Config {
        /// <summary>
        /// 初始化菜单配置
        /// </summary>
        public MenuConfig() {
        }

        /// <summary>
        /// 初始化菜单配置
        /// </summary>
        /// <param name="context">上下文</param>
        public MenuConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 菜单数据
        /// </summary>
        public MenuData Data { get; set; }
    }
}