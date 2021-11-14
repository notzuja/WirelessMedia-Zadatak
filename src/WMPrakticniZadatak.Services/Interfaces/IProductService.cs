using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.DAL.Models;

namespace WMPrakticniZadatak.Services.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(ProductDTO product);
        Product GetProductById(string id);
        List<Product> GetProducts();
        Product UpdateProduct(ProductDTO product);
        bool DeleteProduct(string id);
    }
}
