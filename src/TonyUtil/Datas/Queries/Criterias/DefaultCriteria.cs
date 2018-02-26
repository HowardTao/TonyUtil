using System;
using System.Linq.Expressions;
using TonyUtil.Domains.Repositories;

namespace TonyUtil.Datas.Queries.Criterias
{
    public class DefaultCriteria<TEntity> : ICriteria<TEntity> where TEntity : class 
    {
        /// <summary>
        /// 初始化查询条件
        /// </summary>
        /// <param name="predicate"></param>
        public DefaultCriteria(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity,bool>> Predicate { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        public virtual Expression<Func<TEntity, bool>> GetPredicate()
        {
            return Predicate;
        }
    }
}
