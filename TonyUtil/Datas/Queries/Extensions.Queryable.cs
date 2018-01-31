﻿using System;
using System.Linq;
using System.Linq.Expressions;
using TonyUtil.Datas.Queries.Criterias;
using TonyUtil.Datas.Queries.Internal;
using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Queries
{
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="criteria">查询条件对象</param>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> source, ICriteria<TEntity> criteria) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));
            var predicate = criteria.GetPredicate();
            if (predicate == null)
                return source;
            return source.Where(predicate);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static IQueryable<TEntity> WhereIf<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, bool condition) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (condition == false)
                return source;
            return source.Where(predicate);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public static IQueryable<TEntity> WhereIfNotEmpty<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            predicate = Helper.GetWhereIfNotEmptyExpression(predicate);
            return predicate == null ? source : source.Where(predicate);
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Where(new IntSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max, Boundary boundary = Boundary.Both) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Where(new DoubleSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max, Boundary boundary = Boundary.Both) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Where(new DecimalSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Time</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return includeTime ? source.Where(new DateTimeSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary ?? Boundary.Both)) : source.Where(new DateSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary ?? Boundary.Left));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static IQueryable<TEntity> Pager<TEntity>(this IQueryable<TEntity> source, IPager pager)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (pager == null)
                throw new ArgumentNullException(nameof(pager));
            if (pager.TotalCount <= 0)
                pager.TotalCount = source.Count();
            return source.Skip(pager.GetSkipCount()).Take(pager.PageSize);
        }

        /// <summary>
        /// 转换为分页列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static PagerList<TEntity> ToPagerList<TEntity>(this IQueryable<TEntity> source, IPager pager)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (pager == null)
                throw new ArgumentNullException(nameof(pager));
            var result = new PagerList<TEntity>(pager);
            result.AddRange(source.ToList());
            return result;
        }
    }
}
