using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Extensions;
using Server.Resources.Saving;

namespace Server.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.SaveAsync(company);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Company, SaveCompanyResource>(result.Resource));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, company);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Company, SaveCompanyResource>(result.Resource));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<Company, CompanyResource>(result.Resource));
        }
    }
}
