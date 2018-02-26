namespace TonyUtil.Domains
{
    /// <summary>
    /// 通过对象比较获取变更属性集
    /// </summary>
   public interface ICompareChange<in T> where T:IDomainObject
    {
        /// <summary>
        /// 获取变更属性
        /// </summary>
        /// <param name="other">其他领域对象</param>
        /// <returns></returns>
        ChangeValueCollection GetChanges(T other);
    }
}
