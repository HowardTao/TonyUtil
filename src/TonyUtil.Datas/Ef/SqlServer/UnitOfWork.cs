using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.UnitOfWorks;

namespace TonyUtil.Datas.Ef.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
   public abstract class UnitOfWork:UnitOfWorkBase
    {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="manager">工作单元服务</param>
        protected UnitOfWork(DbContextOptions options, IUnitOfWorkManager manager) : base(options, manager)
        {
        }

        /// <summary>
        /// 获取映射类型列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns></returns>
        protected override IEnumerable<Core.IMap> GetMapTypes(Assembly assembly)
        {
            return Helpers.Reflection.GetTypesByInterface<IMap>(assembly);
        }
    }
}
