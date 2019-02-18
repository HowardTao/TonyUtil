﻿using TonyUtil.Ui.Configs;
using TonyUtil.Ui.TagHelpers;

namespace TonyUtil.Ui.Material.Forms.Configs {
    /// <summary>
    /// 文本框配置
    /// </summary>
    public class TextBoxConfig : Config {
        /// <summary>
        /// 初始化文本框配置
        /// </summary>
        public TextBoxConfig() {
        }

        /// <summary>
        /// 初始化文本框配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        public TextBoxConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 是否多行文本框
        /// </summary>
        public bool IsTextArea { get; set; }

        /// <summary>
        /// 是否日期选择框
        /// </summary>
        public bool IsDatePicker { get; set; }

        /// <summary>
        /// 设置为数值类型
        /// </summary>
        public void Number() {
            SetAttribute( UiConst.Type, "number" );
        }

        /// <summary>
        /// 设置为密码类型
        /// </summary>
        public void Password() {
            SetAttribute( UiConst.Type, "password" );
        }

        /// <summary>
        /// 设置为Email类型
        /// </summary>
        public void Email() {
            SetAttribute( UiConst.Type, "email" );
        }
    }
}
