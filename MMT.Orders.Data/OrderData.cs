using Microsoft.EntityFrameworkCore;
using MMT.Orders.Business;
using MMT.Orders.Contracts.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.Orders.Data
{

    public class OrderData : BaseData<Order>, IOrderData
    {
        public OrderData( OrderDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<Order> GetLatestForUser( string customerId )
        {
            return await TypedContext.Where( o => o.CustomerId == customerId )
                .Include( o => o.OrderItems )
                    .ThenInclude( oi => oi.Product )
                    .AsNoTracking()
                .OrderByDescending( s => s.OrderDate )
                .FirstOrDefaultAsync();
        }

    }
}
