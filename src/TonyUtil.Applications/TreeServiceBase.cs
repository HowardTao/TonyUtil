﻿using System;
using System.Collections.Generic;
using System.Linq;
using TonyUtil.Applications.Dtos;
using TonyUtil.Datas.Queries;
using TonyUtil.Datas.Queries.Trees;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Domains.Repositories;
using TonyUtil.Domains.Trees;

namespace TonyUtil.Applications
{
    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQueryParameter>
        : TreeServiceBase<TEntity, TDto, TQueryParameter, Guid, Guid?>, ITreeService<TDto, TQueryParameter>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>, new()
        where TDto : class, IDto, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter
    {
        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected TreeServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, Guid> repository) : base(unitOfWork, repository)
        {
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, TQueryParameter parameter)
        {
            return queryable.Where(new TreeCriteria<TEntity>(parameter));
        }
    }

    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQueryParameter, TKey, TParentId>
        : CrudServiceBase<TEntity, TDto, TDto, TDto, TQueryParameter, TKey>, ITreeService<TDto, TQueryParameter, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>, new()
        where TDto : class, IDto, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter<TParentId>
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepository<TEntity, TKey> _repository;
        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected TreeServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, TQueryParameter parameter)
        {
            return queryable.Where(new TreeCriteria<TEntity, TKey, TParentId>(parameter));
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public List<string> GetParentIdsFromPath(TDto dto)
        {
            return ToEntity(dto).GetParentIdsFromPath().Select(t => t.ToString()).ToList();
        }
    }
}
