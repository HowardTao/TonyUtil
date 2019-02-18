﻿using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Extensions;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Angular.Renders {
    /// <summary>
    /// angular渲染器基类
    /// </summary>
    public abstract class AngularRenderBase : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化ng-container容器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        protected AngularRenderBase( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化生成器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected override void InitBuilder( TagBuilder builder ) {
            builder.Style( _config );
            builder.Class( _config );
            builder.AddOutputAttributes( _config );
            builder.Angular( _config );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected virtual void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.AddAttribute( $"#{_config.GetValue( UiConst.Id )}" );
        }
    }
}