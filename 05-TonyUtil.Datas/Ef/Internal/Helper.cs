using System;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TonyUtil.Domains;

namespace TonyUtil.Datas.Ef.Internal
{
   internal static class Helper
    {
        public static void InitVersion(EntityEntry entry)
        {
            if(!(entry.Entity is IAggregateRoot entity)) return;
            entity.Version = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        }
    }
}
