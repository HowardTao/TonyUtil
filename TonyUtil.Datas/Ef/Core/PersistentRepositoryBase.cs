﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TonyUtil.Datas.Persistence;
using TonyUtil.Domains;
using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Ef.Core
{
    /// <summary>
    /// 仓储 - 配合持久化对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public abstract class PersistentRepositoryBase<TEntity, TPo> : PersistentRepositoryBase<TEntity, TPo, Guid>
        where TEntity : class, IAggregateRoot<Guid> 
        where TPo : class, IPersistentObject<Guid>
    {
        protected PersistentRepositoryBase(IPersistentStore<TPo> store) : base(store)
        {
        }
    }

    /// <summary>
    /// 仓储 - 配合持久化对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class PersistentRepositoryBase<TEntity,TPo,TKey>:ICompactRepository<TEntity,TKey> where TEntity:class ,IAggregateRoot<TKey> where TPo:class ,IPersistentObject<TKey>
    {
        /// <summary>
        /// 持久化存储
        /// </summary>
        private readonly IPersistentStore<TPo, TKey> _store;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="store">持久化存储</param>
        protected PersistentRepositoryBase(IPersistentStore<TPo, TKey> store)
        {
            _store = store;
        }

        /// <summary>
        /// 将持久化对象转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        /// <returns></returns>
        protected abstract TEntity ToEntity(TPo po);

        /// <summary>
        /// 将实体转换成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        protected abstract TPo ToPo(TEntity entity);

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns></returns>
        public TEntity Find(object id)
        {
            return ToEntity(_store.Find(id));
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task<TEntity> FindAsync(object id)
        {
            return ToEntity(await _store.FindAsync(id));
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        public List<TEntity> FindByIds(params TKey[] ids)
        {
            return _store.FindByIds(ids).Select(ToEntity).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        public List<TEntity> FindByIds(IEnumerable<TKey> ids)
        {
            return _store.FindByIds(ids).Select(ToEntity).ToList();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync(params TKey[] ids)
        {
            var pos = await _store.FindByIdsAsync(ids);
            return pos.Select(ToEntity).ToList();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync(IEnumerable<TKey> ids)
        {
            var pos = await _store.FindByIdsAsync(ids);
            return pos.Select(ToEntity).ToList();
        }

        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public bool Exists(params TKey[] ids)
        {
            return _store.Exists(ids);
        }

        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<bool> ExistsAsync(params TKey[] ids)
        {
            return await _store.ExistsAsync(ids);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add(TEntity entity)
        {
            _store.Add(ToPo(entity));
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Add(IEnumerable<TEntity> entities)
        {
            _store.Add(entities.Select(ToPo));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync(TEntity entity)
        {
            await _store.AddAsync(ToPo(entity));
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await _store.AddAsync(entities.Select(ToPo));
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update(TEntity entity)
        {
            _store.Update(ToPo(entity));
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task UpdateAsync(TEntity entity)
        {
            await _store.UpdateAsync(ToPo(entity));
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public void Remove(TKey id)
        {
            _store.Remove(id);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task RemoveAsync(TKey id)
        {
            await _store.RemoveAsync(id);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Remove(TEntity entity)
        {
            _store.Remove(ToPo(entity));
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task RemoveAsync(TEntity entity)
        {
            await _store.RemoveAsync(ToPo(entity));
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public void Remove(IEnumerable<TKey> ids)
        {
            _store.Remove(ids);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public async Task RemoveAsync(IEnumerable<TKey> ids)
        {
            await _store.RemoveAsync(ids);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Remove(IEnumerable<TEntity> entities)
        {
            _store.Remove(entities.Select(ToPo));
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            await _store.RemoveAsync(entities.Select(ToPo));
        }
    }
}
