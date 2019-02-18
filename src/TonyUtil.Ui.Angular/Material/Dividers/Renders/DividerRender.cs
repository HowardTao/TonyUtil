﻿using TonyUtil.Ui.Angular.Renders;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Dividers.Builders;

namespace TonyUtil.Ui.Material.Dividers.Renders {
    /// <summary>
    /// 分隔线渲染器
    /// </summary>
    public class DividerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化分隔线渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DividerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DividerBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigInset( builder );
            ConfigVertical( builder );
        }

        /// <summary>
        /// 配置间距
        /// </summary>
        private void ConfigInset( TagBuilder builder ) {
            builder.AddAttribute( MaterialConst.Inset, _config.GetBoolValue( MaterialConst.Inset ) );
        }

        /// <summary>
        /// 配置垂直方向
        /// </summary>
        private void ConfigVertical( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Vertical, _config.GetBoolValue( UiConst.Vertical ) );
        }
    }
}