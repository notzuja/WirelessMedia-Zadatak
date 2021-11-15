using Microsoft.Extensions.Options;
using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.Common.Settings;
using WMPrakticniZadatak.DAL.Contexts;
using WMPrakticniZadatak.DAL.Repositories.JSON.Interfaces;
using WMPrakticniZadatak.Services.Interfaces;

namespace WMPrakticniZadatak.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductContext _dbContext;
        private readonly DataAccessOptions _options;
        private readonly bool _useJson;

        public ProductService(IProductRepository productRepository, ProductContext dbContext, IOptions<DataAccessOptions> options)
        {
            _productRepository = productRepository;
            _dbContext = dbContext;
            _options = options.Value;

            _useJson = _options.UseJsonStorage;
        }

        public ProductDTO CreateProduct(ProductDTO product)
        {
            if (_useJson)
                return _productRepository.Create(product).MapDataModeltoDto();

            var dataModel = product.MapDtoToDataModel(false);

            _dbContext.Products.Add(dataModel);
            _dbContext.SaveChanges();

            return dataModel.MapDataModeltoDto();
        }

        public ProductDTO GetProductById(string id)
        {
            if (!Guid.TryParse(id, out Guid productId))
            {
                return null;
            }
            if (_useJson)
                return _productRepository.Read(productId)?.MapDataModeltoDto();

            return _dbContext.Products.Find(productId)?.MapDataModeltoDto();
        }

        public List<ProductDTO> GetProducts()
        {
            if (_useJson)
                return _productRepository.ReadAll()?.Select(x => x.MapDataModeltoDto()).ToList();

            return _dbContext.Products?.Select(x => x.MapDataModeltoDto()).ToList();
        }

        public ProductDTO UpdateProduct(ProductDTO product)
        {
            if (_useJson)
                return _productRepository.Update(product).MapDataModeltoDto();

            var dataModel = product.MapDtoToDataModel(true);

            var updatedEntity = _dbContext.Products.Update(dataModel);
            _dbContext.SaveChanges();

            return updatedEntity.Entity?.MapDataModeltoDto();
        }

        public bool DeleteProduct(string id)
        {
            if (!Guid.TryParse(id, out Guid productId))
            {
                throw new ArgumentException("Invalid GUID");
            }
            if (_useJson)
                return _productRepository.Delete(productId);

            var entityToDelete = _dbContext.Products.Find(productId);

            if (entityToDelete == null) return false;

            _dbContext.Products.Remove(entityToDelete);

            return _dbContext.SaveChanges() > 0;
        }
    }
}
