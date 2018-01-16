using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TonyUtil.Helpers
{
    /// <summary>
    /// TODO
    /// </summary>
   public static class Web
    {
        #region 静态构造方法
        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static Web()
        {
            try
            {
                HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
            }
            catch
            {
            }
        } 
        #endregion

        #region 属性
        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        #endregion

        #region 踩踩踩

        #endregion

        #region 123

        #endregion
    }
}
