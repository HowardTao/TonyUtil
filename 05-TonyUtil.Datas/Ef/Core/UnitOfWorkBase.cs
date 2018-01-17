using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Domains.Sessions;

namespace TonyUtil.Datas.Ef.Core
{
    /// <summary>
    /// 工作单元 TODO
    /// </summary>
   public abstract class UnitOfWorkBase:DbContext,IUnitOfWork
    {
        #region 构造方法
        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="manager">工作单元服务</param>
        protected UnitOfWorkBase(DbContextOptions options, IUnitOfWorkManager manager) : base(options)
        {
            manager?.Register(this);
            TraceId = Guid.NewGuid().ToString();
            Session = Domains.Sessions.Session.Null;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string  TraceId { get; set; }
        /// <summary>
        /// 用户会话
        /// </summary>
        public ISession  Session { get; set; }
        #endregion

        #region OnConfiguring（配置）

        #endregion

        public int Commit()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new concurren(ex);
            }
        }

        public async Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        #region OnModelCreating（配置映射）
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var map in GetMaps())
            {
                map.Map(modelBuilder);
            }
        }

        /// <summary>
        /// 获取映射类型列表
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IMap> GetMaps()
        {
            var result = new List<IMap>();
            foreach (var assembly in GetAssemblies())
            {
                result.AddRange(GetMapTypes(assembly));
            }
            return result;
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly[] GetAssemblies()
        {
            return new[] {GetType().GetTypeInfo().Assembly};
        }

        /// <summary>
        /// 获取映射类型列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns></returns>
        protected virtual IEnumerable<IMap> GetMapTypes(Assembly assembly)
        {
            return Helpers.Reflection.GetTypesByInterface<IMap>(assembly);
        }
        #endregion
    }
}
