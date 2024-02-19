namespace SlayedLifeModels.Shop
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        public int? Duration { get; set; }
        public int TaxId { get; set; }
        public StateTaxDto Tax { get; set; }
        public bool Active { get; set; }
        public int? Discount { get; set; }
    }
}
