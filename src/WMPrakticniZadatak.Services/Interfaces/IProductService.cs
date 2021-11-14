using WMPrakticniZadatak.Common.Models;

namespace WMPrakticniZadatak.Services.Interfaces
{
    public interface IProductService
    {
        ProductDTO CreateProduct(ProductDTO product);
        ProductDTO GetProductById(string id);
        List<ProductDTO> GetProducts();
        ProductDTO UpdateProduct(ProductDTO product);
        bool DeleteProduct(string id);
    }
}
