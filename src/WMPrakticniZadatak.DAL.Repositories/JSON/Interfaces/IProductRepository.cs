using WMPrakticniZadatak.Common.Models;

namespace WMPrakticniZadatak.DAL.Repositories.JSON.Interfaces
{
    public interface IProductRepository
    {
        Product Create(ProductDTO product);
        Product Read(Guid id);
        List<Product> ReadAll();
        Product Update(ProductDTO product);
        bool Delete(Guid id);
    }
}
