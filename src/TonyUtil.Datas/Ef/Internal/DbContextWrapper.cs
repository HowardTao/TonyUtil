using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.Queries;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Domains;
using TonyUtil.Domains.Repositories;
using TonyUtil.Exceptions;

namespace TonyUtil.Datas.Ef.Internal
{
    /// <summary>
    /// 数据上下文包装器
    /// </summary>
    internal class DbContextWrapper<TEntity, TKey> where TEntity : class, IKey<TKey>, IVersion
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        public UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        public DbSet<TEntity> Set => UnitOfWork.Set<TEntity>();

        /// <summary>
        /// 初始化数据上下文包装器
        /// </summary>
        /// <param name="unitOfWork"></param>
        public DbContextWrapper(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (UnitOfWorkBase) unitOfWork;
        }

        /// <summary>
        /// 获取未跟踪的实体集
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> FindAsNoTracking()
        {
            return Set.AsNoTracking();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Find()
        {
            return Set;
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns></returns>
        public TEntity Find(object id)
        {
            return id == null ? null : Set.Find(id);
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(object id)
        {
            if (id == null) return null;
            return await Set.FindAsync(id);
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        /// <returns></returns>
        public List<TEntity> FindByIds(params TKey[] ids)
        {
            return FindByIds((IEnumerable<TKey>) ids);
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        /// <returns></returns>
        public List<TEntity> FindByIds(IEnumerable<TKey> ids)
        {
            return ids == null ? null : Find().Where(t => ids.Contains(t.Id)).ToList();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        /// <returns></returns>
        public async Task<List<TEntity>> FindByIdsAsync(params TKey[] ids)
        {
            return await FindByIdsAsync((IEnumerable<TKey>) ids);
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        /// <returns></returns>
        public async Task<List<TEntity>> FindByIdsAsync(IEnumerable<TKey> ids)
        {
            if (ids == null) return null;
            return await Find().Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Find().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Find().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        public List<TEntity> Query(IQueryBase<TEntity> query)
        {
            return GetQueryResult(Find(), query).ToList();
        }

        /// <summary>
        /// 获取查询结果
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<TEntity> GetQueryResult(IQueryable<TEntity> queryable, IQueryBase<TEntity> query)
        {
            queryable = queryable.Where(query);
            var order = query.GetOrder();
            return string.IsNullOrWhiteSpace(order) ? queryable : queryable.OrderBy(order);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync(IQueryBase<TEntity> query)
        {
            return await GetQueryResult(Find(), query).ToListAsync();
        }

        /// <summary>
        /// 查询 - 返回未跟踪的实体
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        public List<TEntity> QueryAsNoTracking(IQueryBase<TEntity> query)
        {
            return GetQueryResult(FindAsNoTracking(), query).ToList();
        }

        /// <summary>
        /// 查询 - 返回未跟踪的实体
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsNoTrackingAsync(IQueryBase<TEntity> query)
        {
            return await GetQueryResult(FindAsNoTracking(), query).ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TEntity> PagerQuery(IQueryBase<TEntity> query)
        {
            var pager = query.GetPager();
            return GetPagerQueryResult(Find(), query, pager).ToPagerList(pager);
        }

        /// <summary>
        /// 获取分页查询结果
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        private IQueryable<TEntity> GetPagerQueryResult(IQueryable<TEntity> queryable, IQueryBase<TEntity> query,
            IPager pager)
        {
            var order = pager.Order;
            if (string.IsNullOrWhiteSpace(order)) order = "Id";
            return queryable.Where(query).OrderBy(order).Pager(pager);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TEntity>> PagerQueryAsync(IQueryBase<TEntity> query)
        {
            var pager = query.GetPager();
            return await GetPagerQueryResult(Find(), query, pager).ToPagerListAsync(pager);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TEntity> PagerQueryAsNoTracking(IQueryBase<TEntity> query)
        {
            var pager = query.GetPager();
            return GetPagerQueryResult(FindAsNoTracking(), query, pager).ToPagerList(pager);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TEntity>> PagerQueryAsNoTrackingAsync(IQueryBase<TEntity> query)
        {
            var pager = query.GetPager();
            return await GetPagerQueryResult(FindAsNoTracking(), query, pager).ToPagerListAsync(pager);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add(TEntity entity)
        {
            if(entity==null) throw new ArgumentNullException(nameof(entity));
            Set.Add(entity);
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            Set.AddRange(entities);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Set.AddAsync(entity);
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Set.AddRangeAsync(entities);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            UnitOfWork.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中旧的实体</param>
        public void Update(TEntity newEntity,TEntity oldEntity)
        {
            if(newEntity==null) throw new ArgumentNullException(nameof(newEntity));
            if(oldEntity==null) throw new ArgumentNullException(nameof(oldEntity));
            ValidateVersion(newEntity,oldEntity);
            UnitOfWork.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// 验证版本号
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="oldEntity"></param>
        private void ValidateVersion(TEntity newEntity, TEntity oldEntity)
        {
            if(newEntity.Version==null) throw new ConcurrencyExpection();
            if (oldEntity.Version.Where((t, i) => newEntity.Version[i] != t).Any())
            {
                throw new ConcurrencyExpection($"新实体：{newEntity.SafeString()},旧实体：{oldEntity.SafeString()}");
            }
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public void Remove(TKey id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        private void Delete(TEntity entity)
        {
            if(entity==null) return;
            if (entity is IDelete model)
            {
                model.IsDeleted = true;
                return;
            }
            Set.Remove(entity);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task RemoveAsync(TKey id)
        {
            var entity = await FindAsync(id);
            Delete(entity);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Remove(TEntity entity)
        {
            if(entity==null) return;
            Remove(entity.Id);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null) return;
            await RemoveAsync(entity.Id);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public void Remove(IEnumerable<TKey> ids)
        {
            if(ids==null) return;
            var list = FindByIds(ids);
            Delete(list);
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="list"></param>
        private void Delete(List<TEntity> list)
        {
            if(list==null) return;
            if(!list.Any()) return;
            if (list[0] is IDelete)
            {
                foreach (var entity in list.Select(t=>(IDelete)t))
                {
                    entity.IsDeleted = true;
                }
                return;
            }
            Set.RemoveRange(list);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public async Task RemoveAsync(IEnumerable<TKey> ids)
        {
            if (ids == null) return;
            var list = await FindByIdsAsync(ids);
            Delete(list);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Remove(IEnumerable<TEntity> entities)
        {
            if(entities==null) return;
            Remove(entities.Select(t=>t.Id));
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null) return;
            await RemoveAsync(entities.Select(t => t.Id));
        }
    }
}
