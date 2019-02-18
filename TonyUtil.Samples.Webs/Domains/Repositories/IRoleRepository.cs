using System;
using TonyUtil.Samples.Webs.Domains.Models;
using TonyUtil.Security.Identity.Repositories;

namespace TonyUtil.Samples.Webs.Domains.Repositories
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRoleRepository<Role, Guid, Guid?>
    {
    }
}
