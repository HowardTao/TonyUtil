﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TonyUtil.Ui.Builders;
using TonyUtil.Ui.Configs;
using TonyUtil.Ui.Material.Enums;
using TonyUtil.Ui.Material.Forms.Builders;
using TonyUtil.Ui.Material.Forms.Configs;
using TonyUtil.Ui.Material.Forms.Resolvers;

namespace TonyUtil.Ui.Material.Forms.Renders {
    /// <summary>
    /// 文本框渲染器
    /// </summary>
    public class TextBoxRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框渲染器
        /// </summary>
        /// <param name="config">文本框配置</param>
        public TextBoxRender( TextBoxConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = CreateBuilder();
            base.Config( builder );
            ConfigTextArea( builder );
            ConfigDatePicker( builder );
            ConfigTextBox( builder );
            ConfigStandalone( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            TextBoxExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 创建标签生成器
        /// </summary>
        private TagBuilder CreateBuilder() {
            if( _config.IsTextArea )
                return new TextAreaWrapperBuilder();
            if( _config.IsDatePicker )
                return new DatePickerWrapperBuilder();
            return new TextBoxWrapperBuilder();
        }

        /// <summary>
        /// 配置多行文本框
        /// </summary>
        private void ConfigTextArea( TagBuilder builder ) {
            if( _config.IsTextArea == false )
                return;
            builder.AddAttribute( "[minRows]", _config.GetValue( MaterialConst.MinRows ) );
            builder.AddAttribute( "[maxRows]", _config.GetValue( MaterialConst.MaxRows ) );
        }

        /// <summary>
        /// 配置日期选择框
        /// </summary>
        private void ConfigDatePicker( TagBuilder builder ) {
            if( _config.IsDatePicker == false )
                return;
            builder.AddAttribute( "[width]", _config.GetValue( UiConst.Width ) );
            builder.AddAttribute( "startView", _config.GetValue<DateView?>( MaterialConst.StartView )?.Description() );
            builder.AddAttribute( "[touchUi]", _config.GetBoolValue( MaterialConst.TouchUi ) );
            builder.AddAttribute( "minDate", _config.GetValue( MaterialConst.MinDate ) );
            builder.AddAttribute( "maxDate", _config.GetValue( MaterialConst.MaxDate ) );
        }

        /// <summary>
        /// 配置文本框
        /// </summary>
        private void ConfigTextBox( TagBuilder builder ) {
            ConfigType( builder );
            ConfigReadOnly( builder );
            ConfigShowClearButton( builder );
            ConfigValidations( builder );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Type, _config.GetValue<TextBoxType?>( UiConst.Type )?.Description() );
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        private void ConfigReadOnly( TagBuilder builder ) {
            builder.AddAttribute( "[readonly]", _config.GetBoolValue( UiConst.ReadOnly ) );
        }

        /// <summary>
        /// 配置是否显示清除按钮
        /// </summary>
        private void ConfigShowClearButton( TagBuilder builder ) {
            builder.AddAttribute( "[showClearButton]", _config.GetBoolValue( MaterialConst.ShowClearButton ) );
        }

        /// <summary>
        /// 配置验证操作
        /// </summary>
        private void ConfigValidations( TagBuilder builder ) {
            ConfigEmail( builder );
            ConfigMinLength( builder );
            ConfigMaxLength( builder );
        }

        /// <summary>
        /// 配置Email验证
        /// </summary>
        private void ConfigEmail( TagBuilder builder ) {
            builder.AddAttribute( "emailMessage", _config.GetValue( UiConst.EmailMessage ) );
        }

        /// <summary>
        /// 配置最小长度验证
        /// </summary>
        private void ConfigMinLength( TagBuilder builder ) {
            builder.AddAttribute( "[minLength]", _config.GetValue( UiConst.MinLength ) );
            builder.AddAttribute( "minLengthMessage", _config.GetValue( UiConst.MinLengthMessage ) );
        }

        /// <summary>
        /// 配置最大长度验证
        /// </summary>
        private void ConfigMaxLength( TagBuilder builder ) {
            builder.AddAttribute( "[maxLength]", _config.GetValue( UiConst.MaxLength ) );
        }

        /// <summary>
        /// 配置独立
        /// </summary>
        private void ConfigStandalone( TagBuilder builder ) {
            builder.AddAttribute( "[standalone]", _config.GetBoolValue( UiConst.Standalone ) );
        }
    }
}
