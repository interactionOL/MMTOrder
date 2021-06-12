using Microsoft.EntityFrameworkCore;

namespace MMT.Orders.Data
{
    public class BaseData<TEntity> where TEntity : class
    {

        protected readonly OrderDbContext DbContext;

        public BaseData( OrderDbContext dbContext )
        {
            DbContext = dbContext;
        }
        protected DbSet<TEntity> TypedContext => DbContext.Set<TEntity>();
    }
}
