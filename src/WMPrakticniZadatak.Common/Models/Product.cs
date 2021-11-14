using System;

namespace WMPrakticniZadatak.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }

        public ProductDTO MapDataModeltoDto()
        {
            return new ProductDTO
            {
                Id = Id.ToString(),
                Name = Name,
                Description = Description,
                Manufacturer = Manufacturer,
                Category = Category,
                Price = Price,
                Supplier = Supplier
            };
        }
    }
}
