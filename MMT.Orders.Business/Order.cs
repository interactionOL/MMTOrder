using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MMT.Orders.Business
{
    public class Order
    {
        public int OrderId { get; set; }
        [MaxLength( 10 )]
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }

        [MaxLength( 30 )]
        public string ShippingMode { get; set; }
        [MaxLength( 30 )]
        public string OrderSource { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }

}
