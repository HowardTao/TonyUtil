using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Datas.UnitOfWorks;
using TonyUtil.Samples.Webs.Domains.Models;
using TonyUtil.Samples.Webs.Domains.Repositories;

namespace TonyUtil.Samples.Webs.Datas.Repositories.Systems
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : TreeRepositoryBase<Role>, IRoleRepository, IRoleStore<Role>
    {
        /// <summary>
        /// 初始化角色仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            ValidateRole(role, cancellationToken);
            await AddAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        private void ValidateRole(Role role,CancellationToken cancellationToken)
        {
            role.CheckNull(nameof(role));
            cancellationToken.ThrowIfCancellationRequested();
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            ValidateRole(role, cancellationToken);
            await DeleteAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
