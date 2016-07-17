using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusinessAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductServices productServices;

        public ProductController() : base()
        {
            productServices = new ProductServices();
        }

        public ProductController(IProductServices services)
        {
            productServices = services;
        }

        [Route("api/Product")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var products = productServices.GetAllProducts();
                if (products != null)
                {
                    var productEntities = products as List<ProductEntity> ?? products.ToList();
                    if (productEntities.Any())
                        return Request.CreateResponse(HttpStatusCode.OK, productEntities);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
            }
            catch(Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            }
        }

        [Route("api/Product/Get")]
        [HttpGet]
        public HttpResponseMessage Get([FromBody] ProductEntity productEntity)
        {
            try
            {
                var product = productServices.GetProductById(productEntity);
                if (product != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, product);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product id:" + product.Id + " not found");
            }
            catch(Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            } 
        }

        [Route("api/Product/GetByFilter/{priceStart:decimal}/{priceEnd:decimal}")]
        [HttpGet]
        public HttpResponseMessage GetByFilter([FromUri] decimal priceStart, [FromUri] decimal priceEnd, [FromBody] ProductEntity productEntity)
        {
            try
            {
                var products = productServices.GetProductByFilter(priceStart, priceEnd, productEntity);
                if (products != null && products.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, products);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Any product not found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            }
        }

        public HttpResponseMessage Post([FromBody] ProductEntity productEntity)
        {
            try
            {
                var product = productServices.CreateProduct(productEntity);
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            }
        }
        
        public HttpResponseMessage Put([FromBody] ProductEntity productEntity)
        {
            try
            {
                var product = productServices.UpdateProduct(productEntity);
                if (product != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, product);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product id:" + product.Id + " not found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            }
        }
        
        public HttpResponseMessage Delete([FromBody] ProductEntity productEntity)
        {
            try
            {
                var isDeleted = productServices.DeleteProduct(productEntity);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product id:" + productEntity.Id + " deleted");
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product id:" + productEntity.Id + " not found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message);
            }
        }
    }
}
