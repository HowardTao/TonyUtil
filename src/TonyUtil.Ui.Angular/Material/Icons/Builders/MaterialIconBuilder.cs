using TonyUtil.Ui.Angular;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Enums;

namespace TonyUtil.Ui.Material.Icons.Builders {
    /// <summary>
    /// Material图标生成器
    /// </summary>
    public class MaterialIconBuilder : TagBuilder {
        /// <summary>
        /// 初始化图标生成器
        /// </summary>
        public MaterialIconBuilder() : base( "mat-icon" ) {
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="config">配置</param>
        public void SetIcon( IConfig config) {
            SetContent( config.GetValue<MaterialIcon?>( UiConst.MaterialIcon )?.Description() );
        }

        /// <summary>
        /// 设置绑定图标
        /// </summary>
        /// <param name="config">配置</param>
        public void SetBindIcon( IConfig config ) {
            var value = config.GetValue( AngularConst.BindMaterialIcon );
            if( value.IsEmpty() )
                return;
            SetContent( $"{{{{{value}}}}}" );
        }

        /// <summary>
        /// 配置图标大小
        /// </summary>
        /// <param name="config">配置</param>
        public void SetSize( IConfig config ) {
            if( config.Contains( UiConst.Size ) )
                Class( config.GetValue<IconSize>( UiConst.Size ).Description() );
        }
    }
}
