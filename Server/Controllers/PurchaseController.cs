using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<PurchaseResource>> GetPurchasesAsync()
        {
            var purchases = await _purchaseService.ListAllAsync();
            return _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);
        }

        [HttpGet("{id}")]
        public async Task<PurchaseResource> GetPurchaseByIdAsync(int id)
        {
            var purchase = await _purchaseService.FindByIdAsync(id);
            return _mapper.Map<Purchase, PurchaseResource>(purchase);
        }
    }
}
