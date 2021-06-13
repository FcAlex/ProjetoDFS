using Server.Communication;
using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Domains.Services;
using Server.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Purchase>> ListAllAsync() => _purchaseRepository.ListAllAsync();

        public async Task<Purchase> FindByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.FindByIdAsync(id);
            return purchase;
        }

        public async Task<Response<Purchase>> SaveAsync(Purchase purchase)
        {
            try
            {
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new Response<Purchase>(purchase);
            }
            catch (Exception ex)
            {
                return new Response<Purchase>($"An error occorred when saving the user: {ex.Message}");
            }
        }

        public async Task<Response<Purchase>> UpdateAsync(int id, Purchase purchase)
        {
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);

            if (existingPurchase == null)
                return new Response<Purchase>("Purchase not found");

            try
            {
                _purchaseRepository.Update(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new Response<Purchase>(existingPurchase);
            }
            catch (Exception ex)
            {
                return new Response<Purchase>($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public async Task<Response<Purchase>> DeleteAsync(int id)
        {
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);

            if (existingPurchase == null)
                return new Response<Purchase>("User not found");

            try
            {
                _purchaseRepository.Remove(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new Response<Purchase>(existingPurchase);
            }
            catch (Exception ex)
            {
                return new Response<Purchase>($"An error occorred when deleting the user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseByUserAsync(int id) {
            var purchase = await _purchaseRepository.GetPurchaseByUserAsync(id);
            return purchase;
        } 
    }
}
