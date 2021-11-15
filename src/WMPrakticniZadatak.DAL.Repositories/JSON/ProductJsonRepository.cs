using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.Common.Settings;
using WMPrakticniZadatak.DAL.Repositories.JSON.Interfaces;

namespace WMPrakticniZadatak.DAL.Repositories.JSON
{
    public class ProductJsonRepository : IProductRepository
    {
        private readonly DataAccessOptions _dataAccessOptions;
        private readonly IConfiguration _configuration;
        private readonly string _jsonDataPath;

        public ProductJsonRepository(IOptions<DataAccessOptions> dataAccessOptions, IConfiguration configuration)
        {
            _dataAccessOptions = dataAccessOptions.Value ?? throw new ArgumentNullException(nameof(dataAccessOptions));
            _configuration = configuration;

            _jsonDataPath = $@"{_configuration.GetValue<string>("contentRoot").TrimEnd('\\')}{_dataAccessOptions.JsonFileLocation.TrimStart('.')}";
        }

        public Product Create(ProductDTO product)
        {
            var jsonProduct = product.MapDtoToDataModel(false);
            jsonProduct.Id = Guid.NewGuid();

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
            var jsonProduct = product.MapDtoToDataModel(true);

            try
            {
                var products = DeserializeJsonFromFile();
                var productToUpdate = products.Find(x => x.Id == jsonProduct.Id);

                if (productToUpdate == null) return null;

                var productIndex = products.IndexOf(productToUpdate);
                products[productIndex] = jsonProduct;

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
