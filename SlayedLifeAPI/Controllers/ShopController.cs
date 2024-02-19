using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore.Shop;
using SlayedLifeModels.Shop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlayedLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService shopService;
        private readonly IMapper mapper;
        public ShopController(IShopService shopService, IMapper mapper)
        {
            this.shopService = shopService;
            this.mapper = mapper;
        }

        [HttpPost("service")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceDto))]
        public async Task<IActionResult> Service(Service service)
        {
            try
            {
                var result = await shopService.CreateService(service);
                
                var response = mapper.Map<ServiceDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("service/update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceDto))]
        public async Task<IActionResult> ServiceUpdate(Service service)
        {
            try
            {
                var result = await shopService.UpdateService(service);

                var response = mapper.Map<ServiceDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("service/{userId}/{skip}/{take}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceDto>))]
        public async Task<IActionResult> Service([FromRoute] int userId, [FromRoute] int skip, [FromRoute] int take)
        {
            try
            {
                var result = await shopService.GetServices(userId, skip, take);

                var response = mapper.Map<List<ServiceDto>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("product")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        public async Task<IActionResult> Product(ProductDto productDto)
        {
            try
            {
                Product product = mapper.Map<Product>(productDto);
                var result = await shopService.CreateProduct(product);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("product/update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        public async Task<IActionResult> ProductUpdate(Product product)
        {
            try
            {
                var result = await shopService.UpdateProduct(product);

                var response = mapper.Map<ProductDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("product/{userId}/{skip}/{take}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
        public async Task<IActionResult> Product([FromRoute]int userId, [FromRoute]int skip, [FromRoute]int take)
        {
            try
            {
                var result = await shopService.GetProducts(userId, skip, take);
                var response = mapper.Map<List<ProductDto>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("state/taxes")]
        public async Task<IActionResult> StateTaxes()
        {
            var result = await shopService.GetStateTaxes();
            var response = mapper.Map<List<StateTaxDto>>(result);
            return Ok(response);
        }
    }
}
