using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ProductServices : IProductServices
    {
        List<ProductEntity> productEntities;

        public ProductServices()
        {
            productEntities = new List<ProductEntity>() {
                new ProductEntity() {
                    Id = 1,
                    Name = "XCV",
                    Color = "Red",
                    Size = "42",
                    Price = 15000
                },
                new ProductEntity() {
                    Id = 2,
                    Name = "WFG",
                    Color = "Blue",
                    Size = "39",
                    Price = 20000
                },
                new ProductEntity() {
                    Id = 3,
                    Name = "HTY",
                    Color = "Green",
                    Size = "20",
                    Price = 980
                }
            };
        }

        public ProductEntity GetProductById(ProductEntity productEntity)
        {
            return productEntities.Where(x => x.Id == productEntity.Id).FirstOrDefault();
        }

        public IEnumerable<ProductEntity> GetProductByFilter(decimal priceStart, decimal priceEnd, ProductEntity productEntity)
        {
            return productEntities.Where(x => x.Id == productEntity.Id ||
                                        x.Name == productEntity.Name ||
                                        x.Color == productEntity.Color ||
                                        x.Size == productEntity.Size ||
                                        (x.Price >= priceStart && x.Price <= priceEnd));
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return productEntities;
        }

        public ProductEntity CreateProduct(ProductEntity productEntity)
        {
            productEntities.Add(productEntity);
            return productEntities.Where(x => x.Id == productEntity.Id).FirstOrDefault();
        }

        public ProductEntity UpdateProduct(ProductEntity productEntity)
        {
            var product = productEntities.Where(x => x.Id == productEntity.Id).FirstOrDefault();
            product.Id = productEntity.Id;
            product.Name = productEntity.Name;
            product.Color = productEntity.Color;
            product.Size = productEntity.Size;
            product.Price = productEntity.Price;
            return product;
        }

        public bool DeleteProduct(ProductEntity productEntity)
        {
            productEntities.Remove(productEntity);
            return true;
        }
    }
}
