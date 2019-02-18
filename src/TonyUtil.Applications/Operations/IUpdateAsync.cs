using System.Threading.Tasks;
using TonyUtil.Applications.Aspects;
using TonyUtil.Applications.Dtos;
using TonyUtil.Validations.Aspects;

namespace TonyUtil.Applications.Operations {
    /// <summary>
    /// 修改操作
    /// </summary>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    public interface IUpdateAsync<in TUpdateRequest> where TUpdateRequest : IRequest, new() {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [UnitOfWork]
        Task UpdateAsync( [Valid] TUpdateRequest request );
    }
}