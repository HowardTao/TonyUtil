﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Ef
{
    /// <summary>
    /// 查询扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 转换为分页列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        public static async Task<PagerList<TEntity>> ToPagerListAsync<TEntity>(this IQueryable<TEntity> source,
            IPager pager)
        {
            if(source==null) throw new ArgumentNullException(nameof(source));
            if (pager == null) throw new ArgumentNullException(nameof(pager));
            var result = new PagerList<TEntity>(pager);
            result.AddRange(await source.ToListAsync());
            return result;
        }
    }
}
