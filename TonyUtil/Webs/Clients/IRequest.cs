﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TonyUtil.Webs.Clients
{
    /// <summary>
    /// Http请求
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public interface IRequest<out TRequest> where TRequest : IRequest<TRequest>
    {
        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        /// <returns></returns>
        TRequest ContentType(HttpContentType contentType);

        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        /// <returns></returns>
        TRequest ContentType(string contentType);

        /// <summary>
        ///  设置Cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        TRequest Cookie(Cookie cookie);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">有效时间，单位：天</param>
        /// <returns></returns>
        TRequest Cookie(string name, string value, double expiresDate);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">到期时间</param>
        /// <returns></returns>
        TRequest Cookie(string name, string value, DateTime expiresDate);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="path">源服务器URL子集</param>
        /// <param name="domain">所属域</param>
        /// <param name="expiresDate">到期时间</param>
        /// <returns></returns>
        TRequest Cookie(string name, string value, string path = "/", string domain = null,
            DateTime? expiresDate = null);

        /// <summary>
        /// 超时时间
        /// </summary>
        /// <param name="timeout">超时时间，单位：秒</param>
        /// <returns></returns>
        TRequest Timeout(int timeout);

        /// <summary>
        /// 请求头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        TRequest Header<T>(string key, T value);

        /// <summary>
        /// 添加参数字典
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TRequest Data(IDictionary<string, string> parameters);

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        TRequest Data<T>(string key, T value);

        /// <summary>
        /// 添加Json参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">值</param>
        /// <returns></returns>
        TRequest JsonData<T>(T value);

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,参数为响应结果</param>
        TRequest OnFail(Action<string> action);

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        TRequest OnFail(Action<string, HttpStatusCode> action);

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        string Result();

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        Task<string> ResultAsync();
    }
}
