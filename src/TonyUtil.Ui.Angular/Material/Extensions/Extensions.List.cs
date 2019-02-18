using TonyUtil.Ui.Components.Internal;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Lists;

namespace TonyUtil.Ui.Material.Extensions {
    /// <summary>
    /// 列表扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 复选框位置
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="position">位置</param>
        public static TComponent CheckboxPosition<TComponent>( this TComponent component, XPosition position ) where TComponent : ISelectList {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.CheckboxPosition,position );
            } );
            return component;
        }
    }
}
