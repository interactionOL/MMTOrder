using Microsoft.AspNetCore.Mvc;
using MMT.Orders.Contracts.Dtos.Services;
using MMT.Orders.Contracts.Services;
using System.Threading.Tasks;

namespace MMT.Orders.Api.Controllers
{
    [Route( "[controller]" )]
    public class OrdersController : BaseController
    {
        private readonly IOrderService _service;

        public OrdersController( IOrderService service )
        {
            _service = service;
        }


        [Route( "latest" )]
        [HttpPost]
        public async Task<ActionResult<LatestOrderResponseDto>> GetLatest( [FromBody] CustomerRequestDto requestDto )
        {
            return await ExecuteWithErrorHandling( async () =>
            {
                LatestOrderResponseDto response = await _service.GetLatest( requestDto );
                return response;
            } );
        }


    }
}
