using System;
using System.Linq.Expressions;
using TonyUtil.Helpers;
using TonyUtil.Properties;

namespace TonyUtil.Datas.Queries.Internal
{
    /// <summary>
    /// 查询工具类
    /// </summary>
   internal static class Helper
    {

        public static Expression<Func<TEntity, bool>> GetWhereInfNotEmptyExpression<TEntity>(
            Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            if (predicate == null) return null;
            if (Lambda.GetConditionCount(predicate) > 1)
                throw new InvalidOperationException(string.Format(LibraryResource.OnlyOnePredicate, predicate));
            var value = predicate.Value();
            if (string.IsNullOrWhiteSpace(value.SafeString())) return null;
            return predicate;
        }
    }
}
