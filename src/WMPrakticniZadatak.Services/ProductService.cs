﻿using Microsoft.Extensions.Options;
using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.Common.Settings;
using WMPrakticniZadatak.DAL.Contexts;
using WMPrakticniZadatak.DAL.Models;
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

        public Product CreateProduct(ProductDTO product)
        {
            if (_useJson)
                return _productRepository.Create(product);

            var dataModel = product.MapDtoToDataModel(false);

            _dbContext.Products.Add(dataModel);
            _dbContext.SaveChanges();

            return dataModel;
        }

        public Product GetProductById(string id)
        {
            if (!Guid.TryParse(id, out Guid productId))
            {
                throw new ArgumentException("Invalid GUID");
            }
            if (_useJson)
                return _productRepository.Read(productId);

            return _dbContext.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            if (_useJson)
                return _productRepository.ReadAll();

            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(ProductDTO product)
        {
            if (_useJson)
                return _productRepository.Update(product);

            var dataModel = product.MapDtoToDataModel(true);

            var updatedEntity = _dbContext.Update(dataModel);
            _dbContext.SaveChanges();

            return updatedEntity.Entity;
        }

        public bool DeleteProduct(string id)
        {
            if (!Guid.TryParse(id, out Guid productId))
            {
                throw new ArgumentException("Invalid GUID");
            }
            if (_useJson)
                return _productRepository.Delete(productId);

            _dbContext.Remove(productId);

            return _dbContext.SaveChanges() > 0;
        }
    }
}
