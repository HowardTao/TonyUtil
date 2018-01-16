﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TonyUtil.Webs.Clients
{
    /// <summary>
    /// 内容类型
    /// </summary>
    public enum HttpContentType
    {
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        [Description("application/x-www-form-urlencoded")]
        FormUrlEncoded,
        /// <summary>
        /// application/json
        /// </summary>
        [Description("application/json")]
        Json
    }
}
