namespace Business_Layer.Dtos
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
    }
}
