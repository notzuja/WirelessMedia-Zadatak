using WMPrakticniZadatak.DAL.Models;

namespace WMPrakticniZadatak.Common.Models
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }

        public Product MapDtoToDataModel()
        {
            var jsonProduct = new Product
            {
                Name = Name,
                Description = Description,
                Manufacturer = Manufacturer,
                Category = Category,
                Price = Price,
                Supplier = Supplier
            };

            if (Guid.TryParse(Id, out var jsonProductGuid))
            {
                jsonProduct.Id = jsonProductGuid;
            }
            else
            {
                throw new ArgumentException("Invalid product GUID");
            }

            return jsonProduct;
        }
    }
}
