namespace SlayedLifeModels.Shop
{
    public class ProductSizeDto
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
    }
}
