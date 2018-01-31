using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TonyUtil.Datas.UnitOfWorks
{
    /// <summary>
    /// 工作单元服务
    /// </summary>
    public class UnitOfWorkManager:IUnitOfWorkManager
    {
        private readonly List<IUnitOfWork> _unitOfWorks;

        /// <summary>
        /// 初始化工作单元服务
        /// </summary>
        public UnitOfWorkManager()
        {
            _unitOfWorks = new List<IUnitOfWork>();
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        public async Task CommitAsync()
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                await unitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public void Register(IUnitOfWork unitOfWork)
        {
            if(unitOfWork==null) throw new ArgumentNullException(nameof(unitOfWork));
            if (!_unitOfWorks.Contains(unitOfWork)) _unitOfWorks.Add(unitOfWork);
        }
    }
}
