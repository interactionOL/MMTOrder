using AutoMapper;
using MMT.Orders.Business;
using MMT.Orders.Contracts.Dtos.Services;
using MMT.Orders.Contracts.Profiles;
using NUnit.Framework;

namespace MMT.Orders.Common.Tests
{
    public class MappingProfileTests
    {

        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration( cfg =>
            {
                cfg.AddProfile<OrderProfile>();
            } );
            mapper = config.CreateMapper();
        }

        [Test]
        public void OrderMappingHidesProductDetail_WhenOrderIsGift()
        {
            OrderItem item = new OrderItem();
            Product product = new Product
            {
                Colour = "Blue",
                PackHeight = 25.0M,
                PackWidth = 10.0M,
                ProductId = 1,
                ProductName = "Something Awesome",
                Size = "NA"
            };
            item.Product = product;
            Order order = new Order();
            order.ContainsGift = true;
            order.OrderItems = new System.Collections.Generic.List<OrderItem>();
            order.OrderItems.Add( item );
            item.Order = order;

            var result = mapper.Map<OrderItemResponseDto>( item );

            Assert.AreEqual( result.Product, "Gift" );

        }

        [Test]
        public void OrderMappingShowsProductDetail_WhenOrderIsNotGift()
        {
            OrderItem item = new OrderItem();
            Product product = new Product
            {
                Colour = "Blue",
                PackHeight = 25.0M,
                PackWidth = 10.0M,
                ProductId = 1,
                ProductName = "Something Awesome",
                Size = "NA"
            };
            item.Product = product;
            Order order = new Order();
            order.ContainsGift = false;
            order.OrderItems = new System.Collections.Generic.List<OrderItem>();
            order.OrderItems.Add( item );
            item.Order = order;

            var result = mapper.Map<OrderItemResponseDto>( item );

            Assert.AreEqual( result.Product, "Something Awesome" );

        }
    }
}