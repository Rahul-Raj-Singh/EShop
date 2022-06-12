using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using MongoDB.Driver;

namespace EShop.Product.Repository
{
    public interface IProductRepository
    {
        Task<ProductCreated> AddProduct(CreateProduct product);
        Task<CreateProduct> GetProduct(string productID);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<CreateProduct> _collection;

        public ProductRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<CreateProduct>("product");
        }
        public async Task<ProductCreated> AddProduct(CreateProduct product)
        {
            await _collection.InsertOneAsync(product);

            return new ProductCreated {ProductID = product.ProductID, CreatedAt = DateTime.Now};
        }

        public async Task<CreateProduct> GetProduct(string productID)
        {
            var product =  _collection.AsQueryable().FirstOrDefault(p => p.ProductID == productID);
            
            await Task.CompletedTask;

            return product;
        }
    }
}