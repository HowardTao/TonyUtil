﻿using System;
using System.Linq.Expressions;
using TonyUtil.Datas.Queries.Criterias;
using TonyUtil.Datas.Queries.Internal;
using TonyUtil.Domains.Repositories;
using TonyUtil.Helpers;

namespace TonyUtil.Datas.Queries
{
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class Query<TEntity> : Query<TEntity, Guid> where TEntity : class { }

    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public class Query<TEntity, TKey> : IQuery<TEntity, TKey> where TEntity : class
    {

        /// <summary>
        /// 查询参数
        /// </summary>
        private readonly IQueryParameter _parameter;
        /// <summary>
        /// 查询条件
        /// </summary>
        private Expression<Func<TEntity, bool>> _predicate;
        /// <summary>
        /// 初始化查询对象
        /// </summary>
        private readonly OrderByBuilder _orderByBuilder;

        /// <summary>
        /// 初始化查询对象
        /// </summary>
        public Query() : this(new QueryParameter())
        {
        }

        /// <summary>
        /// 初始化查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public Query(IQueryParameter parameter)
        {
            _parameter = parameter;
            _orderByBuilder = new OrderByBuilder();
            OrderBy(parameter.Order);
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        public Expression<Func<TEntity, bool>> GetPredicate()
        {
            return _predicate;
        }

        /// <summary>
        /// 获取排序条件
        /// </summary>
        /// <returns></returns>
        public string GetOrder()
        {
            return _orderByBuilder.Generate();
        }

        /// <summary>
        /// 获取分页参数
        /// </summary>
        /// <returns></returns>
        public IPager GetPager()
        {
            return new Pager(_parameter.Page,_parameter.PageSize,_parameter.TotalCount,GetOrder());
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IQuery<TEntity, TKey> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return And(predicate);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="criteria">查询条件</param>
        /// <returns></returns>
        public IQuery<TEntity, TKey> Where(ICriteria<TEntity> criteria)
        {
            return And(criteria.GetPredicate());
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <returns></returns>
        public IQuery<TEntity, TKey> WhereIf(Expression<Func<TEntity, bool>> predicate, bool condition)
        {
            return condition ? this : Where(predicate);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public IQuery<TEntity, TKey> WhereIfNotEmpty(Expression<Func<TEntity, bool>> predicate)
        {
            predicate = Helper.GetWhereInfNotEmptyExpression(predicate);
            return predicate == null ? this : And(predicate);
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public IQuery<TEntity, TKey> Between<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both)
        {
            return Where(new IntSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public IQuery<TEntity, TKey> Between<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max, Boundary boundary = Boundary.Both)
        {
            return Where(new DoubleSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public IQuery<TEntity, TKey> Between<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max, Boundary boundary = Boundary.Both)
        {
            return Where(new DecimalSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max, boundary));
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Time</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public IQuery<TEntity, TKey> Between<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true,
            Boundary? boundary = null)
        {
            return includeTime
                ? Where(new DateTimeSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max,
                    boundary ?? Boundary.Both))
                : Where(new DateSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max,
                    boundary ?? Boundary.Left));
        }

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        /// <param name="desc">是否降序</param>
        public IQuery<TEntity, TKey> OrderBy<TProperty>(Expression<Func<TEntity, TProperty>> expression, bool desc = false)
        {
            return OrderBy(Lambda.GetName(expression), desc);
        }

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="propertyName">排序属性</param>
        /// <param name="desc">是否降序</param>
        public IQuery<TEntity, TKey> OrderBy(string propertyName, bool desc = false)
        {
            _orderByBuilder.Add(propertyName,desc);
            return this;
        }

        /// <summary>
        /// 与连接
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public IQuery<TEntity, TKey> And(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = _predicate.And(predicate);
            return this;
        }

        /// <summary>
        /// 与连接
        /// </summary>
        /// <param name="query">查询对象</param>
        public IQuery<TEntity, TKey> And(IQuery<TEntity, TKey> query)
        {
            And(query.GetPredicate());
            OrderBy(query.GetOrder());
            return this;
        }

        /// <summary>
        /// 或连接
        /// </summary>
        /// <param name="predicates">查询条件</param>
        public IQuery<TEntity, TKey> Or(params Expression<Func<TEntity, bool>>[] predicates)
        {
            if (predicates == null) return this;
            foreach (var item in predicates)
            {
                var predicate = Helper.GetWhereInfNotEmptyExpression(item);
                if(predicate==null) continue;
                _predicate = _predicate.Or(predicate);
            }
            return this;
        }

        /// <summary>
        /// 或连接
        /// </summary>
        /// <param name="query">查询对象</param>
        public IQuery<TEntity, TKey> Or(IQuery<TEntity, TKey> query)
        {
            _predicate = _predicate.Or(query.GetPredicate());
            OrderBy(query.GetOrder());
            return this;
        }
    }
}
