using TonyUtil.Ui.Angular;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Components.Internal;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Operations;
using TonyUtil.Ui.Operations.Bind;

namespace TonyUtil.Ui.Extensions {
    /// <summary>
    /// 表单扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 禁用
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="disabled">禁用表达式</param>
        public static TComponent Disable<TComponent>( this TComponent component, string disabled ) where TComponent : IOption, IDisabled {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Disabled, disabled );
            } );
            return component;
        }

        /// <summary>
        /// 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Standalone<TComponent>( this TComponent component ) where TComponent : IOption, IDisabled {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Standalone, true );
            } );
            return component;
        }

        /// <summary>
        /// 添加绑定名称 [name]
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="name">名称</param>
        public static TComponent BindName<TComponent>( this TComponent component, string name ) where TComponent : IOption, IBindName {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( AngularConst.BindName, name );
            } );
            return component;
        }
    }
}
