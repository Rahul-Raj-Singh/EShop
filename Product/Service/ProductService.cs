using System;
using System.Threading.Tasks;
using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using EShop.Product.Repository;

namespace EShop.Product.Service
{
    public interface IProductService
    {
        Task<ProductCreated> AddProduct(CreateProduct product);
        Task<CreateProduct> GetProduct(string productID);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductCreated> AddProduct(CreateProduct product)
        {
            return await _repository.AddProduct(product);
        }

        public async Task<CreateProduct> GetProduct(string productID)
        {
            return await _repository.GetProduct(productID);
        }
    }
}