using MMT.Orders.Contracts.Dtos.Services;
using System.Threading.Tasks;

namespace MMT.Orders.Contracts.Services
{
    public interface IOrderService
    {
        Task<LatestOrderResponseDto> GetLatest( CustomerRequestDto request );
    }
}
