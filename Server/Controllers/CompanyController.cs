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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await _companyService.ListAllAsync();
            return _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
        }

        [HttpGet("{id}")]
        public async Task<CompanyResource> GetById(int id)
        {
            var company = await _companyService.FindById(id);
            return _mapper.Map<Company, CompanyResource>(company);
        }
    }
}
