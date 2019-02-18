﻿using System.Threading.Tasks;
using TonyUtil.Applications.Aspects;
using TonyUtil.Applications.Dtos;
using TonyUtil.Validations.Aspects;

namespace TonyUtil.Applications.Operations {
    /// <summary>
    /// 保存操作
    /// </summary>
    /// <typeparam name="TRequest">参数类型</typeparam>
    public interface ISaveAsync<in TRequest> where TRequest : IRequest, IKey, new() {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        [UnitOfWork]
        Task SaveAsync( [Valid] TRequest request );
    }
}