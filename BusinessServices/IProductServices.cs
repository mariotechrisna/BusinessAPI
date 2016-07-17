using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IProductServices
    {
        ProductEntity GetProductById(ProductEntity productEntity);
        IEnumerable<ProductEntity> GetProductByFilter(decimal priceStart, decimal priceEnd, ProductEntity productEntity);
        IEnumerable<ProductEntity> GetAllProducts();
        ProductEntity CreateProduct(ProductEntity productEntity);
        ProductEntity UpdateProduct(ProductEntity productEntity);
        bool DeleteProduct(ProductEntity productEntity);
    }
}
