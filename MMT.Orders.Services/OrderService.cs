using AutoMapper;
using MMT.Orders.Common.Exceptions;
using MMT.Orders.Contracts.Data;
using MMT.Orders.Contracts.Dtos.Services;
using MMT.Orders.Contracts.Services;
using System.Threading.Tasks;

namespace MMT.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderData _orderData;
        private readonly IMapper _mapper;

        public OrderService( ICustomerService customerService, IOrderData orderData, IMapper mapper )
        {
            _customerService = customerService;
            _orderData = orderData;
            _mapper = mapper;
        }

        public async Task<LatestOrderResponseDto> GetLatest( CustomerRequestDto request )
        {
            if ( request == null )
            {
                throw new BadRequestException( "Null request" );
            }

            var latest = await _orderData.GetLatestForUser( request.CustomerId );
            if ( latest == null )
            {
                //throw new NotFoundException( $"Unable to find order for user {request.User} ({request.CustomerId})" );
            }

            var user = await _customerService.GetUser( request.User );
            if ( user == null )
            {
                throw new NotFoundException( $"Unable to find orders for {request.User}" );
            }
            if ( user.CustomerId != request.CustomerId )
            {
                throw new BadRequestException( "User Email and CustomerId are not correct, please check" );
            }
            var response = new LatestOrderResponseDto();
            response.Order = _mapper.Map<OrderResponseDto>( latest );
            response.Order = _mapper.Map( user, response.Order );
            response.Customer = _mapper.Map<CustomerResponseDto>( user );

            return response;
        }
    }
}
