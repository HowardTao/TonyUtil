﻿using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Icons.Renders;

namespace TonyUtil.Ui.Material.Lists.Renders {
    /// <summary>
    /// 导航列表图标渲染器
    /// </summary>
    public class NavListIconRender : IconRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化导航列表图标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public NavListIconRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        protected override void Config( TagBuilder builder ) {
            base.Config( builder );
            ConfigPosition( builder );
        }

        /// <summary>
        /// 配置位置
        /// </summary>
        private void ConfigPosition( TagBuilder builder ) {
            if ( _config.GetValue<XPosition?>( UiConst.Position ) != XPosition.Right )
                builder.AddAttribute( "mat-list-icon" );
        }
    }
}