using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Domains.Auditing;
using TonyUtil.Domains.Sessions;
using TonyUtil.Exceptions;

namespace TonyUtil.Datas.Ef.Core
{
    /// <summary>
    /// 工作单元
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
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="optionsBuilder">配置生成器</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            EnableLog(optionsBuilder);
        }

        /// <summary>
        /// 启用日志 
        /// </summary>
        /// <param name="builder"></param>
        protected void EnableLog(DbContextOptionsBuilder builder)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Commit（提交）
        /// <summary>
        /// 提交，返回影响的行数
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            try
            {
                return SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyExpection(ex);
            }
        }
        #endregion

        #region CommitAsync（异步提交）
        /// <summary>
        /// 异步提交，返回影响的行数
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            try
            {
                return await SaveChangesAsync();
            }
            catch (DBConcurrencyException exception)
            {
                throw new ConcurrencyExpection(exception);
            }
        } 
        #endregion

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

        #region SaveChanges（保存更改）
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            SaveChangesBefore();
            return base.SaveChanges();
        }

        /// <summary>
        /// 保存更改前操作
        /// </summary>
        protected virtual void SaveChangesBefore()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                        case EntityState.Added:
                        InterceptAddedOperation(entry);
                        break;
                        case EntityState.Modified:
                        InterceptModifiedOperation(entry);
                        break;
                        case EntityState.Deleted:
                        InterceptDeletedOperation(entry);
                       break;
                }
            }
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void InterceptAddedOperation(EntityEntry entry)
        {
            InitCreationAudited(entry);
            InitModificationAudited(entry);
        }

        /// <summary>
        /// 初始化创建审计信息
        /// </summary>
        /// <param name="entry"></param>
        private void InitCreationAudited(EntityEntry entry)
        {
            CreationAuditedInitializer.Init(entry,GetSession());
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        /// <param name="entry"></param>
        protected virtual void InterceptModifiedOperation(EntityEntry entry)
        {
            InitModificationAudited(entry);
        }

        /// <summary>
        /// 初始化修改审计信息
        /// </summary>
        /// <param name="entry"></param>
        private void InitModificationAudited(EntityEntry entry)
        {
            ModificationAuditedInitializer.Init(entry,GetSession());
        }

        /// <summary>
        /// 获取用户会话
        /// </summary>
        /// <returns></returns>
        protected virtual ISession GetSession()
        {
            return Session;
        }

        /// <summary>
        /// 拦截删除操作
        /// </summary>
        /// <param name="entry"></param>
        public virtual void InterceptDeletedOperation(EntityEntry entry) { }

        #endregion

        #region SaveChangesAsync（异步保存更改）
        /// <summary>
        /// 异步保存更改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SaveChangesBefore();
            return base.SaveChangesAsync(cancellationToken);
        }  
        #endregion

    }
}
