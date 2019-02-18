﻿using TonyUtil.Ui.Components;
using TonyUtil.Ui.Components.Internal;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Operations.Form.Validations;

namespace TonyUtil.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 验证
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 必填项
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="message">错误消息</param>
        public static TComponent Required<TComponent>( this TComponent component, string message = null ) where TComponent : IRequired {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Required,true );
                config.SetAttribute( UiConst.RequiredMessage, message );
            } );
            return component;
        }

        /// <summary>
        /// 最小长度
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="message">错误消息</param>
        public static TComponent MinLength<TComponent>( this TComponent component, int minLength, string message = null ) where TComponent : IComponent, IMinLength {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.MinLength,minLength );
                config.SetAttribute( UiConst.MinLengthMessage,message );
            } );
            return component;
        }

        /// <summary>
        /// 最大长度
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="maxLength">最大长度</param>
        public static TComponent MaxLength<TComponent>( this TComponent component, int maxLength ) where TComponent : IComponent, IMaxLength {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.MaxLength, maxLength );
            } );
            return component;
        }
    }
}
