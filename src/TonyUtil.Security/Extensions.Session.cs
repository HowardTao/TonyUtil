﻿using TonyUtil.Domains.Sessions;

namespace TonyUtil.Security
{
    /// <summary>
    /// 用户会话扩展
    /// </summary>
   public static partial class Extensions
    {
        /// <summary>
        /// 获取当前应用程序
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetApplication(this ISession session)
        {
            return "";
        }

        /// <summary>
        /// 获取当前租户
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetTenant(this ISession session)
        {
            return "";
        }

        /// <summary>
        /// 获取当前操作人姓名
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetFullName(this ISession session)
        {
            return "";
        }

        /// <summary>
        /// 获取当前操作人角色名
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetRoleName(this ISession session)
        {
            return "";
        }
    }
}
