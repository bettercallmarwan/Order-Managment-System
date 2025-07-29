namespace Business_Layer.Dtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public List<OrderItemDto> Items { get; set; } = new(); //(prodId, quantity, unitprice)
    }
}
