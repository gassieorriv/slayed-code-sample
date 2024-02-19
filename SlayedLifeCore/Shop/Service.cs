﻿using System;

namespace SlayedLifeCore.Shop
{
    public class Service
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public virtual StateTax Tax { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int? Discount { get; set; }
        public int? Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
