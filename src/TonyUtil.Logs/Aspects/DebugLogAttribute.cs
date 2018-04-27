namespace TonyUtil.Logs.Aspects
{
    /// <summary>
    /// 调试日志
    /// </summary>
   public class DebugLogAttribute:LogAttributeBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        protected override bool Enabled(ILog log)
        {
            return log.IsDebugEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        protected override void WriteLog(ILog log)
        {
            log.Debug();
        }
    }
}
