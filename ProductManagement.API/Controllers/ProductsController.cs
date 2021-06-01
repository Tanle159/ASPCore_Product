using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProductManagement.Application.ProductsService.Services;
using ProductManagement.Application.ProductsService.DTO;
using ProductManagement.Common.StatusActions;

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductServices productServices;
        public ProductsController(IProductServices productServices, ILogger<ProductsController> logger)
        {
            this.productServices = productServices;
            this._logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<StatusActionBase> GetProductById(int id)
           => await this.productServices.GetProductById(id);

        [HttpGet]
        public async Task<StatusActionBase> GetAllProduct()
           => await this.productServices.GetAllProduct();

        [HttpPost]
        public async Task<StatusActionBase> AddPostProduct(ProductDTO productDTO)
        {
            _logger.LogInformation("AddProduct");
            return await this.productServices.AddProduct(productDTO);
        }
        [HttpPost("{id}")]
        public async Task<StatusActionBase> UpdatePostProduct([FromBody] ProductDataUpdate productDTO, [FromRoute] int id)
        {
            _logger.LogInformation("UpdatePostProduct");
            productDTO.ID = id;
            return await this.productServices.EditProductData(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<StatusActionBase> DeleteProduct(int id)
        {
            _logger.LogInformation("DeleteProduct");
            return await this.productServices.DeleteProduct(id);
        }
            

     
        [HttpPut]
        public async Task<StatusActionBase> AddPutProduct([FromBody] ProductDTO productDTO)
        => await this.productServices.AddProduct(productDTO);

        [HttpPut("{id}")]
        public async Task<StatusActionBase> UpdatePutProduct([FromBody] ProductDataUpdate productDTO, [FromRoute] int id)
        {
            _logger.LogInformation("UpdatePutProduct");
            productDTO.ID = id;
            return await this.productServices.EditProductData(productDTO);
        }

        [HttpPut("updateprice/{id}")]
        public async Task<StatusActionBase> UpdatePricetProduct([FromBody] double? price, [FromRoute] int id)
        {
            _logger.LogInformation("UpdatePricetProduct");
            return await this.productServices.UpdatePrice(price,id);
        }

        [HttpGet("filter")]
        public async Task<StatusActionBase> GetProductByQuery([FromQuery]string name, [FromQuery] int[] categories, [FromQuery] double? priceFrom, [FromQuery] double? priceTo, [FromQuery] int? page, [FromQuery] int? size)
            => await this.productServices.GetByQuery(name, new List<int>(categories), priceFrom, priceTo, page, size);


        [HttpPost("filter")]
        public async Task<StatusActionBase> GetProductByQueryPost(ProductInfoFilter filter)
           => await this.productServices.GetByQuery(filter.Name, filter.Categories, filter.PriceFrom, filter.PriceTo, filter.Page, filter.Size);

    }
}
