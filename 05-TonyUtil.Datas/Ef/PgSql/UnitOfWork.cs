﻿using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.Ef.Internal;
using TonyUtil.Datas.UnitOfWorks;

namespace TonyUtil.Datas.Ef.PgSql
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
            return Helpers.Reflection.GetTypesByInterface<SqlServer.IMap>(assembly);
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptAddedOperation(EntityEntry entry)
        {
            base.InterceptAddedOperation(entry);
            Helper.InitVersion(entry);
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptModifiedOperation(EntityEntry entry)
        {
            base.InterceptModifiedOperation(entry);
            Helper.InitVersion(entry);
        }
    }
}