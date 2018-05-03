using System.Threading.Tasks;
using TonyUtil.Applications.Aspects;
using TonyUtil.Applications.Dtos;
using TonyUtil.Validations.Aspects;

namespace TonyUtil.Applications.Operations
{
    /// <summary>
    /// 更新操作
    /// </summary>
    /// <typeparam name="TRequest">修改参数类型</typeparam>
    public interface ISaveAsync<in TRequest> where TRequest:IRequest,new()
    {
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task SaveAsync([Valid] TRequest request);
    }
}
