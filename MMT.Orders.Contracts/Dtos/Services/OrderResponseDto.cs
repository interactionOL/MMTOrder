using System;
using System.Collections.Generic;

namespace MMT.Orders.Contracts.Dtos.Services
{
    public class OrderResponseDto
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime DeliveryExpected { get; set; }

        public List<OrderItemResponseDto> OrderItems { get; set; }
    }
}
