using System.Collections.Generic;
using System.Threading.Tasks;
using TonyUtil.Applications.Dtos;

namespace TonyUtil.Applications.Operations {
    /// <summary>
    /// 获取全部数据
    /// </summary>
    public interface IGetAllAsync<TDto> where TDto : IResponse, new() {
        /// <summary>
        /// 获取全部
        /// </summary>
        Task<List<TDto>> GetAllAsync();
    }
}
