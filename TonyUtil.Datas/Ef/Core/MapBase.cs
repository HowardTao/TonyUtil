using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TonyUtil.Datas.Ef.Core
{
    /// <summary>
    /// 映射配置
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
   public abstract class MapBase<TEntity>:IMap where TEntity:class 
    {
        /// <summary>
        /// 模型生成器
        /// </summary>
        protected ModelBuilder ModelBuilder { get; private set; }

        public void Map(ModelBuilder modelBuilder)
        {
            ModelBuilder = modelBuilder;
            var builder = modelBuilder.Entity<TEntity>();
            MapTable(builder);
            MapVersion(builder);
            MapProperties(builder);
            MapAssociations(builder);
        }

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder"></param>
        protected abstract void MapTable(EntityTypeBuilder<TEntity> builder);

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void MapVersion(EntityTypeBuilder<TEntity> builder) { }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void MapProperties(EntityTypeBuilder<TEntity> builder) { }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void MapAssociations(EntityTypeBuilder<TEntity> builder) { }
    }
}
