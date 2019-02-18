using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TonyUtil.Logs;
using TonyUtil.Logs.Extensions;

namespace TonyUtil.Samples.Webs
{
    /// <summary>
    /// Ӧ�ó���
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Ӧ�ó�����ڵ�
        /// </summary>
        /// <param name="args">��ڵ����</param>
        public static void Main(string[] args)
        {
            try
            {
                BuildWebHost(args).Run();
            }
            catch (System.Exception ex)
            {
                ex.Log(Log.GetLog().Caption("Ӧ�ó�������ʧ��"));
            }
        }

        /// <summary>
        /// ����Web����
        /// </summary>
        /// <param name="args">��ڵ����</param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
