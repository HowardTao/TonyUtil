using System;
using System.IO;
using TonyUtil.Ui.Components;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Forms.Renders;
using TonyUtil.Ui.Renders;

namespace TonyUtil.Ui.Material.Forms {
    /// <summary>
    /// 表单
    /// </summary>
    public class Form : ContainerBase<IDisposable>, IForm {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单
        /// </summary>
        /// <param name="writer">流写入器</param>
        public Form( TextWriter writer ) : base( writer ) {
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
            return new FormRender( _config );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IDisposable GetWrapper() {
            return new ContainerWrapper( this );
        }
    }
}
