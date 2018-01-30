using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TonyUtil.Datas.Ef.Core;
using TonyUtil.Domains;

namespace TonyUtil.Datas.Ef.PgSql
{
    /// <summary>
    /// 聚合根映射配置
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
   public abstract class AggregateRootMap<TEntity>:MapBase<TEntity>,SqlServer.IMap where TEntity:class ,IVersion
    {
        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        /// <param name="builder"></param>
        protected override void MapVersion(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(t => t.Version).IsRowVersion();
        }
    }
}
