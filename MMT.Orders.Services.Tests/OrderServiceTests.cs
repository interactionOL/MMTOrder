using AutoMapper;
using MMT.Orders.Business;
using MMT.Orders.Common.Exceptions;
using MMT.Orders.Contracts.Data;
using MMT.Orders.Contracts.Dtos.Apis;
using MMT.Orders.Contracts.Dtos.Services;
using MMT.Orders.Contracts.Profiles;
using MMT.Orders.Contracts.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MMT.Orders.Services.Tests
{

    public class OrderServiceTests
    {
        private OrderService orderService;
        private IMapper mapper;
        Mock<ICustomerService> service;
        Mock<IOrderData> data;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration( cfg =>
            {
                cfg.AddProfile<OrderProfile>();
            } );
            mapper = config.CreateMapper();

            service = new Mock<ICustomerService>();
            service.Setup( p => p.GetUser( It.IsAny<string>() ) )
                .Returns( Task.FromResult( new CustomerApiResponseDto() { CustomerId = "DUMMY" } ) );

            data = new Mock<IOrderData>();
            var order = new Business.Order();
            order.CustomerId = "CustomerId";
            data.Setup( p => p.GetLatestForUser( It.IsAny<string>() ) ).Returns( Task.FromResult( order ) );
            orderService = new OrderService( service.Object, data.Object, mapper );
        }

        [Test]
        public void WhenUserDoesntMatchCustomer_ReturnInvalidRequest()
        {
            //cat.owner@mmtdigital.co.uk (ID= C34454)
            CustomerRequestDto dto = new CustomerRequestDto();
            dto.CustomerId = "C34454changed";
            dto.User = "cat.owner@mmtdigital.co.uk";

            Assert.ThrowsAsync<BadRequestException>( async () => await orderService.GetLatest( dto ) );
        }

        [Test]
        public void WhenUserDoesntMatchCustomerCat_ReturnInvalidRequest()
        {
            //cat.owner@mmtdigital.co.uk (ID= C34454)
            CustomerRequestDto dto = new CustomerRequestDto();
            dto.CustomerId = "C344541";
            dto.User = "cat.owner@mmtdigital.co.uk";

            Assert.ThrowsAsync<BadRequestException>( async () => await orderService.GetLatest( dto ) );
        }

        [Test]
        public async Task WhenUserHasNoOrders_ReturnEmptyOrderObject()
        {
            //cat.owner@mmtdigital.co.uk (ID= C34454)
            CustomerRequestDto dto = new CustomerRequestDto();
            dto.CustomerId = "C34454";
            dto.User = "cat.owner@mmtdigital.co.uk";

            data.Setup( s => s.GetLatestForUser( It.IsAny<string>() ) ).Returns( Task.FromResult<Order>( null ) );
            service.Setup( s => s.GetUser( It.IsAny<string>() ) ).Returns( Task.FromResult<CustomerApiResponseDto>( new CustomerApiResponseDto
            {
                CustomerId = "C34454" //Check userID matches
            } ) );

            var result = await orderService.GetLatest( dto );
            Assert.IsNull( result.Order );
            Assert.IsNotNull( result.Customer );

        }
    }
}