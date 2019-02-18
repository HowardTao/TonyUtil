using TonyUtil.Ui.Components;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Extensions;
using TonyUtil.Ui.Material.Forms.Configs;
using TonyUtil.Ui.Material.Lists.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Lists {
    /// <summary>
    /// 选择列表
    /// </summary>
    public class SelectList : ComponentBase, ISelectList {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化选择列表
        /// </summary>
        public SelectList() {
            _config = new SelectConfig();
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
            return new SelectListWrapperRender( _config );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public ISelectList Enum<TEnum>() {
            return this.Add( Helpers.Enum.GetItems<TEnum>().ToArray() );
        }
    }
}