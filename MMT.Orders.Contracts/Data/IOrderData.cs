using MMT.Orders.Business;
using System.Threading.Tasks;

namespace MMT.Orders.Contracts.Data
{
    public interface IOrderData
    {
        Task<Order> GetLatestForUser( string customerId );
    }
}
