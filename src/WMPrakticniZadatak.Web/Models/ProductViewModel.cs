using WMPrakticniZadatak.Common.Models;

namespace WMPrakticniZadatak.Web.Models
{
    public class ProductViewModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
    }
}
