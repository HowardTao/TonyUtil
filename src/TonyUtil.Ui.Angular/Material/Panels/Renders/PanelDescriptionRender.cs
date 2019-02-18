using TonyUtil.Ui.Angular.Renders;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Panels.Builders;

namespace TonyUtil.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板描述渲染器
    /// </summary>
    public class PanelDescriptionRender : AngularRenderBase {
        /// <summary>
        /// 初始化面板描述渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelDescriptionRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PanelDescriptionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}