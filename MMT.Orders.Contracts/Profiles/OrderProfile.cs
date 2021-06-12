using AutoMapper;
using MMT.Orders.Business;
using MMT.Orders.Contracts.Dtos.Apis;
using MMT.Orders.Contracts.Dtos.Services;

namespace MMT.Orders.Contracts.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponseDto>()
                .ForMember( m => m.OrderNumber, m => m.MapFrom( o => o.OrderId ) )
                .ForMember( m => m.DeliveryAddress, m => m.MapFrom( o => "Address TBC" ) );

            CreateMap<CustomerApiResponseDto, OrderResponseDto>()
                .ForMember( m => m.DeliveryAddress, m => m.MapFrom( c => c.FullAddress ) );

            CreateMap<OrderItem, OrderItemResponseDto>()
                .ForMember( m => m.Product, m => m.MapFrom( item => item.Order.ContainsGift ? "Gift" : item.Product.ProductName ) )
                .ForMember( m => m.PriceEach, m => m.MapFrom( item => item.Price ) );

            CreateMap<CustomerApiResponseDto, CustomerResponseDto>();

        }
    }
}
