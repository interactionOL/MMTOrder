using MMT.Orders.Contracts.Dtos.Apis;
using System.Threading.Tasks;

namespace MMT.Orders.Contracts.Services
{
    public interface ICustomerService
    {
        Task<CustomerApiResponseDto> GetUser( string email );
    }
}
