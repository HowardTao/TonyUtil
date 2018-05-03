using TonyUtil.Applications.Aspects;
using TonyUtil.Applications.Dtos;
using TonyUtil.Validations.Aspects;

namespace TonyUtil.Applications.Operations
{
    /// <summary>
    /// 保存操作
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public interface ISave<in TRequest> where TRequest:IRequest,new ()
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        [UnitOfWork]
        void Save([Valid] TRequest request);
    }
}
