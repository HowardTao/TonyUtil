using System;
using System.Linq.Expressions;
using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Queries.Criterias
{
    /// <summary>
    /// 与查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class AndCriteria<TEntity>:ICriteria<TEntity> where TEntity:class 
    {

        public AndCriteria(Expression<Func<TEntity, bool>> left, Expression<Func<TEntity, bool>> right)
        {
            Predicate = left.And(right);
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity,bool>> Predicate { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        public Expression<Func<TEntity, bool>> GetPredicate()
        {
            return Predicate;
        }
    }
}
