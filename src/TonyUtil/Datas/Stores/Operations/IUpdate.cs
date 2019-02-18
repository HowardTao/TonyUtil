﻿using System.Collections.Generic;
using TonyUtil.Domains;
using TonyUtil.Validations.Aspects;

namespace TonyUtil.Datas.Stores.Operations {
    /// <summary>
    /// 修改实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IUpdate<in TEntity, in TKey> where TEntity : class, IKey<TKey>, IVersion {
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update( [Valid] TEntity entity );
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update( [Valid] IEnumerable<TEntity> entities );
    }
}