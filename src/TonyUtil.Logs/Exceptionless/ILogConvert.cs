﻿using System.Collections.Generic;

namespace TonyUtil.Logs.Exceptionless
{
    /// <summary>
    /// 日志转换器
    /// </summary>
   public interface ILogConvert
   {
        /// <summary>
        /// 转换
        /// </summary>
        /// <returns></returns>
       List<Item> To();
   }
}
