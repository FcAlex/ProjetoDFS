using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Extensions;
using Server.Resources.Saving;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }

        [HttpGet("{id}")]
        public async Task<ProductResource> GetById(int id)
        {
            var product = await _productService.FindById(id);
            return _mapper.Map<Product, ProductResource>(product);
        }

        [HttpGet("company/{id}")]
        public async Task<IEnumerable<ProductResource>> GetProductsByCompanyId(int id)
        {
            var products = await _productService.GetProductsByCompanyId(id);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Product, ProductResource>(result.Resource));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Product, ProductResource>(result.Resource));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Product, ProductResource>(result.Resource));
        }
    }
}
