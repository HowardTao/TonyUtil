﻿using TonyUtil.Ui.Angular.Builders;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;

namespace TonyUtil.Ui.Angular.Renders {
    /// <summary>
    /// router-outlet路由出口渲染器
    /// </summary>
    public class RouterOutletRender : AngularRenderBase {
        /// <summary>
        /// 初始化router-outlet路由出口渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public RouterOutletRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new RouterOutletBuilder();
        }
    }
}