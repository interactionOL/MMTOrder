namespace MMT.Orders.Contracts.Dtos.Services
{
    public class OrderItemResponseDto
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int PriceEach { get; set; }
    }
}
