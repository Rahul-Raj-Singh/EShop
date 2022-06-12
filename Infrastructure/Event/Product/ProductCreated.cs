using System;

namespace EShop.Infrastructure.Event.Product
{
    public class ProductCreated
    {
        public string ProductID { get; set; }
        public string ProdutName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}