using TonyUtil.Ui.Components;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Forms.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Forms {
    /// <summary>
    /// 复选框
    /// </summary>
    public class CheckBox : ComponentBase, ICheckBox {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框
        /// </summary>
        public CheckBox() {
            _config = new Config();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new CheckBoxRender( _config );
        }
    }
}
