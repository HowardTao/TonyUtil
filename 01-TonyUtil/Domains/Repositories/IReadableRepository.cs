using System.Linq;
using TonyUtil.Dependency;

namespace TonyUtil.Domains.Repositories
{
   public interface IReadableRepository
    {
    }

    public interface IReadableRepository<TEntity,in TKey>:IScopeDependency where TEntity:class ,IAggregateRoot
    {
        IQueryable<TEntity> FindAsoNoTracking();
    }
}
