using Microsoft.EntityFrameworkCore;
using TonyUtil.Datas.UnitOfWorks;

namespace TonyUtil.Samples.Webs.Datas.SqlServer
{

    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : TonyUtil.Datas.Ef.SqlServer.UnitOfWork, ISampleUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        protected SampleUnitOfWork(DbContextOptions options, IUnitOfWorkManager unitOfWorkManager) : base(options, unitOfWorkManager)
        {
        }
    }

}
