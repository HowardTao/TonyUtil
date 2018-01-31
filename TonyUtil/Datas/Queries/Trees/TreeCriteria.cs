using System;
using System.Linq.Expressions;
using TonyUtil.Domains.Repositories;
using TonyUtil.Domains.Trees;

namespace TonyUtil.Datas.Queries.Trees
{
    /// <summary>
    /// 树型查询条件
    /// </summary>
    public class TreeCriteria<TEntity> : TreeCriteria<TEntity, Guid, Guid?> where TEntity : ITreeEntity<TEntity, Guid, Guid?>
    {
        /// <summary>
        /// 初始化树型查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria(ITreeQueryParameter parameter) : base(parameter)
        {
            if (parameter.ParentId != null)
                Predicate = Predicate.And(t => t.ParentId == parameter.ParentId);
        }
    }

    public class TreeCriteria<TEntity,TKey,TParentId>:ICriteria<TEntity> where TEntity:ITreeEntity<TEntity,TKey,TParentId>
    {

        /// <summary>
        /// 初始化树型查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria(ITreeQueryParameter<TParentId> parameter)
        {
            if (parameter.Level != null) Predicate = Predicate.And(t => t.Level == parameter.Level);
            if (!string.IsNullOrWhiteSpace(parameter.Path))
                Predicate = Predicate.And(t => t.Path.StartsWith(parameter.Path));
            if (parameter.Enabled != null) Predicate = Predicate.And(t => t.Enabled == parameter.Enabled);
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
