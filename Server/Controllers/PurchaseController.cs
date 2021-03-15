using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Resources;
using System;
using System.Collections.Generic;
using Server.Extensions;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService purchaseService, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
        {
            var purchases = await _purchaseService.ListAllAsync();
            return _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);
        }

        [HttpGet("{id}")]
        public async Task<PurchaseResource> GetByIdAsync(int id)
        {
            var purchase = await _purchaseService.FindByIdAsync(id);
            return _mapper.Map<Purchase, PurchaseResource>(purchase);
        }

        [HttpPost]
        public async Task<IActionResult> PutPurchase([FromBody] PurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<PurchaseResource, Purchase>(resource);
            var result = await _purchaseService.SaveAsync(purchase);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Purchase, PurchaseResource>(result.Purchase));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] PurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<PurchaseResource, Purchase>(resource);
            var result = await _purchaseService.UpdateAsync(id, purchase);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Purchase, PurchaseResource>(result.Purchase));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _purchaseService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Purchase, PurchaseResource>(result.Purchase));
        }
    }
}
