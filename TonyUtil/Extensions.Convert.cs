using System;
using System.Collections.Generic;
using System.Linq;

namespace TonyUtil
{
    /// <summary>
    /// 系统扩展 - 类型转换
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 安全转换给字符串,去除两端空格,当值为null时返回""
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SafeString(this object input)
        {
            return input == null ? string.Empty : input.ToString().Trim();
        }

        /// <summary>
        /// 转换为32位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static int ToInt(this object input)
        {
            return Helpers.Convert.ToInt(input);
        }

        /// <summary>
        /// 转换为32位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static int? ToIntOrNull(this object input)
        {
            return Helpers.Convert.ToIntOrNull(input);
        }

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static long ToLong(this object input)
        {
            return Helpers.Convert.ToLong(input);
        }

        /// <summary>
        /// 转换为64位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static long? ToLongOrNull(this object input)
        {
            return Helpers.Convert.ToLongOrNull(input);
        }

        /// <summary>
        /// 转换为64位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static double ToDouble( this object input)
        {
            return Helpers.Convert.ToDouble(input);
        }

        /// <summary>
        /// 转换为64位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static double? ToDoubleOrNull(this object input)
        {
            return Helpers.Convert.ToDoubleOrNull(input);
        }

        /// <summary>
        /// 转换为128位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object input)
        {
            return Helpers.Convert.ToDecimal(input);
        }

        /// <summary>
        /// 转换为128位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static decimal? ToDecimalOrNull(this object input)
        {
            return Helpers.Convert.ToDecimalOrNull(input);
        }

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static bool ToBool(this object input)
        {
            return Helpers.Convert.ToBool(input);
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static bool? ToBoolOrNull(this object input)
        {
            return Helpers.Convert.ToBoolOrNull(input);
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static DateTime ToDate(this object input)
        {
            return Helpers.Convert.ToDate(input);
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static DateTime? ToDateOrNull(this object input)
        {
            return Helpers.Convert.ToDateOrNull(input);
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static Guid ToGuid(this object input)
        {
            return Helpers.Convert.ToGuid(input);
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns></returns>
        public static Guid? ToGuidOrNull(this object input)
        {
            return Helpers.Convert.ToGuidOrNull(input);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="input">以逗号分隔的元素集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        /// <returns></returns>
        public static List<Guid> ToGuidList(this string input)
        {
            return Helpers.Convert.ToGuidList(input);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="input">字符串集合</param>
        /// <returns></returns>
        public static List<Guid> ToGuidList(this IList<string> input)
        {
            if (input == null) return new List<Guid>();
            return input.Select(t => t.ToGuid()).ToList();
        }
    }
}
