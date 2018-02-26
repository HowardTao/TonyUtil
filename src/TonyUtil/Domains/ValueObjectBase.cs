using System;
using System.Linq;
using System.Reflection;

namespace TonyUtil.Domains
{
    /// <summary>
    /// 值对象
    /// </summary>
    /// <typeparam name="TValueObject">值对象类型</typeparam>
    public abstract class ValueObjectBase<TValueObject> : DomainBase<TValueObject>, IEquatable<TValueObject>
        where TValueObject : ValueObjectBase<TValueObject>
    {
        /// <summary>
        /// 相等性比较
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TValueObject other)
        {
            return this == other;
        }

        /// <summary>
        /// 相等性比较
        /// </summary>
        public override bool Equals(object other)
        {
            return Equals(other as TValueObject);
        }

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var properties = GetType().GetTypeInfo().GetProperties();
            return properties.Select(property => property.GetValue(this)).Where(value => value != null)
                .Aggregate(0, (current, value) => current ^ value.GetHashCode());
        }

        /// <summary>
        /// 相等性比较
        /// </summary>
        public static bool operator ==(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            if ((object) left == null && (object) right == null) return true;
            if (!(left is TValueObject) || !(right is TValueObject)) return false;
            var properties = left.GetType().GetTypeInfo().GetProperties();
            return properties.All(property => property.GetValue(left) == property.GetValue(right));
        }

        /// <summary>
        /// 不相等性比较
        /// </summary>
        public static bool operator !=(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        /// <returns></returns>
        public virtual TValueObject Clone()
        {
            return Helpers.Convert.To<TValueObject>(MemberwiseClone());
        }
    }
}
