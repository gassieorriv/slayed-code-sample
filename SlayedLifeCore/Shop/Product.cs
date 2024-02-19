using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlayedLifeCore.Shop
{
    public class Product
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string DiscountType { get; set; }
        public string ShippingType { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public virtual StateTax Tax { get; set; }
        public decimal Shipping { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public decimal? Discount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public ICollection<ProductSize> ProductSize { get; set; }
    }
}
