using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TonyUtil.Logs;
using TonyUtil.Logs.Extensions;

namespace TonyUtil.Samples.Webs
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main(string[] args)
        {
            try
            {
                BuildWebHost(args).Run();
            }
            catch (System.Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        /// <summary>
        /// 创建Web宿主
        /// </summary>
        /// <param name="args">入口点参数</param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
