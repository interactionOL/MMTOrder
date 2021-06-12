namespace MMT.Orders.Contracts.Dtos.Services
{
    public class LatestOrderResponseDto
    {
        public CustomerResponseDto Customer { get; set; }
        public OrderResponseDto Order { get; set; }
    }
}
