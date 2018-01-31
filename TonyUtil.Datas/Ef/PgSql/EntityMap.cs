﻿using TonyUtil.Datas.Ef.Core;

namespace TonyUtil.Datas.Ef.PgSql
{
    /// <summary>
    /// 实体映射配置
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract  class EntityMap<TEntity>:MapBase<TEntity>,SqlServer.IMap where TEntity:class { }
}
