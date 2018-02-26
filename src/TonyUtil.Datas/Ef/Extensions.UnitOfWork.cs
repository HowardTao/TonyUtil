using System.Linq;
using Microsoft.EntityFrameworkCore;
using TonyUtil.Datas.UnitOfWorks;

namespace TonyUtil.Datas.Ef
{
    /// <summary>
    /// Ef工作单元扩展
    /// </summary>
   public static partial class Extensions
    {
        public static void ClearCache(this IUnitOfWork unitOfWork)
        {
            var dbContext = unitOfWork as DbContext;
            dbContext?.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
        }
    }
}
