﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TonyUtil.Helpers;

namespace TonyUtil.Domains.Trees
{
    /// <summary>
    /// 树型实体
    /// </summary>
    /// <typeparam name="TEntity">树型实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    /// <typeparam name="TParentId">父编号类型</typeparam>
    public abstract class TreeEntityBase<TEntity, TKey, TParentId> : AggregateRoot<TEntity, TKey>, ITreeEntity<TEntity, TKey, TParentId> where TEntity : ITreeEntity<TEntity, TKey, TParentId>
    {
        /// <summary>
        /// 父对象
        /// </summary>
        private TEntity _parent;

        /// <summary>
        /// 初始化树型实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        protected TreeEntityBase(TKey id, string path, int level)
            : base(id)
        {
            Path = path;
            Level = level;
        }

        /// <summary>
        /// 父对象
        /// </summary>
        public virtual TEntity Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                InitPath();
            }
        }

        /// <summary>
        /// 父编号
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Required]
        public virtual string Path { get; private set; }

        /// <summary>
        /// 级数
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SortId { get; set; }

        /// <summary>
        /// 初始化路径
        /// </summary>
        public virtual void InitPath()
        {
            InitPath(Parent);
        }

        /// <summary>
        /// 初始化路径
        /// </summary>
        /// <param name="parent">父节点</param>
        public void InitPath(TEntity parent)
        {
            if (Equals(parent, null))
            {
                Level = 1;
                Path = $"{Id},";
                return;
            }
            Level = parent.Level + 1;
            Path = $"{parent.Path}{Id},";
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        /// <param name="excludeSelf">是否排除当前节点,默认排除自身</param>
        public List<TKey> GetParentIdsFromPath(bool excludeSelf = true)
        {
            if (string.IsNullOrWhiteSpace(Path))
                return new List<TKey>();
            var result = Path.Split(',').Where(id => !string.IsNullOrWhiteSpace(id) && id != ",").ToList();
            if (excludeSelf)
                result = result.Where(id => id.SafeString().ToLower() != Id.SafeString().ToLower()).ToList();
            return result.Select(Helpers.Convert.To<TKey>).ToList();
        }
    }

    /// <summary>
    /// 树型实体
    /// </summary>
    /// <typeparam name="TEntity">树型实体类型</typeparam>
    public abstract class TreeEntityBase<TEntity> : TreeEntityBase<TEntity, Guid, Guid?> where TEntity : ITreeEntity<TEntity, Guid, Guid?>
    {
        /// <summary>
        /// 初始化树型实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        protected TreeEntityBase(Guid id, string path, int level)
            : base(id, path, level)
        {
        }
    }
}
