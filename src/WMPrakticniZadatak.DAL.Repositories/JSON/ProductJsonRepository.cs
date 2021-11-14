using Microsoft.Extensions.Options;
using System.Text.Json;
using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.Common.Settings;
using WMPrakticniZadatak.DAL.Models;
using WMPrakticniZadatak.DAL.Repositories.JSON.Interfaces;

namespace WMPrakticniZadatak.DAL.Repositories.JSON
{
    public class ProductJsonRepository : IProductRepository
    {
        private readonly DataAccessOptions _dataAccessOptions;
        private readonly string _jsonDataPath;

        public ProductJsonRepository(IOptions<DataAccessOptions> dataAccessOptions)
        {
            _dataAccessOptions = dataAccessOptions.Value ?? throw new ArgumentNullException(nameof(dataAccessOptions));
            _jsonDataPath = _dataAccessOptions.JsonFileLocation ?? throw new ArgumentNullException(nameof(dataAccessOptions));
        }

        public Product Create(ProductDTO product)
        {
            var jsonProduct = product.MapDtoToDataModel();

            try
            {
                var products = DeserializeJsonFromFile();

                products.Add(jsonProduct);

                var jsonData = JsonSerializer.Serialize(products);
                File.WriteAllText(_jsonDataPath, jsonData);

                return jsonProduct;
            }
            catch (Exception ex)
            {
                throw new JsonException("Error writing JSON data", ex);
            }
        }

        public Product Read(Guid id)
        {
            try
            {
                return DeserializeJsonFromFile().Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new JsonException("Error reading JSON data", ex);
            }
        }

        public List<Product> ReadAll()
        {
            try
            {
                return DeserializeJsonFromFile();
            }
            catch (Exception ex)
            {
                throw new JsonException("Error reading JSON data", ex);
            }
        }

        public Product Update(ProductDTO product)
        {
            var jsonProduct = product.MapDtoToDataModel();

            try
            {
                var products = DeserializeJsonFromFile();
                var productToUpdate = products.Find(x => x.Id == jsonProduct.Id);

                if (productToUpdate == null) return null;

                productToUpdate = jsonProduct;

                var jsonData = JsonSerializer.Serialize(products);
                File.WriteAllText(_jsonDataPath, jsonData);

                return productToUpdate;
            }
            catch (Exception ex)
            {
                throw new JsonException("Error writing JSON data", ex);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var products = DeserializeJsonFromFile();
                var productToDelete = products.Find(x => x.Id == id);

                if (productToDelete == null) return false;

                products.Remove(productToDelete);

                var jsonData = JsonSerializer.Serialize(products);
                File.WriteAllText(_jsonDataPath, jsonData);

                return true;
            }
            catch (Exception ex)
            {
                throw new JsonException("Error writing JSON data", ex);
            }
        }

        private List<Product> DeserializeJsonFromFile()
        {
            var jsonData = File.ReadAllText(_jsonDataPath);
            return JsonSerializer.Deserialize<List<Product>>(jsonData);
        }
    }
}
