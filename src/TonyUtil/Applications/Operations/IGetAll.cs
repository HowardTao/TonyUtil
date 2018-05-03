using System.Collections.Generic;
using TonyUtil.Applications.Dtos;

namespace TonyUtil.Applications.Operations
{
    /// <summary>
    /// 获取全部数据
    /// </summary>
   public interface IGetAll<TDto> where TDto:IResponse,new()
    {
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        List<TDto> GetAll();
    }
}
