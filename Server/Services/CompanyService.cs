using Server.Communication;
using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Domains.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Company> FindById(int id) => _companyRepository.FindByIdAsync(id);

        public Task<IEnumerable<Company>> ListAllAsync() => _companyRepository.ListAllAsync();

        public async Task<Response<Company>> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new Response<Company>(company);
            }
            catch (Exception ex)
            {
                return new Response<Company>($"An error occorred when saving the user: {ex.Message}");
            }
        }

        public async Task<Response<Company>> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new Response<Company>("Company not found");

            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new Response<Company>(existingCompany);
            }
            catch (Exception ex)
            {
                return new Response<Company>($"An error occorred when updating the user: {ex.Message}");
            }
        }

        public async Task<Response<Company>> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new Response<Company>("Company not found");

            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new Response<Company>(existingCompany);
            }
            catch (Exception ex)
            {
                return new Response<Company>($"An error occorred when deleting the user: {ex.Message}");
            }

        }
    }
}
