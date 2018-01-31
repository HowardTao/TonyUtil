using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace TonyUtil.Helpers
{
    /// <summary>
    /// Web操作
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

        #region Client(Web客户端)

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <returns></returns>
        public static  TonyUtil.Webs.Clients.WebClient Client()
        {
            return new TonyUtil.Webs.Clients.WebClient();
        }

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <returns></returns>
        public static TonyUtil.Webs.Clients.WebClient<TResult> Client<TResult>() where TResult:class 
        {
            return new TonyUtil.Webs.Clients.WebClient<TResult>();
        }

        #endregion

        #region Url（请求地址）
        /// <summary>
        /// 请求地址
        /// </summary>
        public static string Url => HttpContext?.Request?.GetDisplayUrl();

        #endregion

        #region Host（主机）
        /// <summary>
        /// 主机
        /// </summary>
        public static string Host => HttpContext == null ? Dns.GetHostName() : GetClientHostName();

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        /// <returns></returns>
        private static string GetClientHostName()
        {
            var address = GetRemoteAddress();
            if (string.IsNullOrWhiteSpace(address)) return Dns.GetHostName();
            var result = Dns.GetHostEntry(IPAddress.Parse(address)).HostName;
            if (result == "localhost.localdomain") return Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获取远程地址
        /// </summary>
        /// <returns></returns>
        private static string GetRemoteAddress()
        {
            return HttpContext?.Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? HttpContext?.Request?.Headers["REMOTE_ADDR"];
        }
        #endregion

        #region Browser（浏览器）
        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => HttpContext?.Request?.Headers["User-Agent"];

        #endregion

        #region GetFiles（获取客户端文件集合）

        /// <summary>
        /// 获取客户端文件集合
        /// </summary>
        /// <returns></returns>
        public static List<IFormFile> GetFiles()
        {
            var result = new List<IFormFile>();
            var files = HttpContext.Request.Form.Files;
            if (files == null || files.Count == 0) return result;
            result.AddRange(files.Where(file=>file?.Length>0));
            return result;
        }
        #endregion

        #region GetFile（获取客户端文件）

        /// <summary>
        /// 获取客户端文件
        /// </summary>
        /// <returns></returns>
        public static IFormFile GetFile()
        {
            var files = GetFiles();
            return files.Count == 0 ? null : files.First();
        }

        #endregion
    }
}
