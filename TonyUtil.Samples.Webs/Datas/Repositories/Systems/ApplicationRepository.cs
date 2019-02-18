﻿using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Samples.Webs.Domains.Models;
using TonyUtil.Samples.Webs.Domains.Repositories;

namespace TonyUtil.Samples.Webs.Datas.Repositories.Systems
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected ApplicationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
