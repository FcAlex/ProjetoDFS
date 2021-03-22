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
            Console.WriteLine(purchase.User);
            Console.WriteLine(purchase.Product);
            return purchase;
        }

        public async Task<PurchaseResponse> SaveAsync(Purchase purchase)
        {
            try
            {
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(purchase);
            }
            catch (Exception ex)
            {
                return new PurchaseResponse($"An error occorred when saving the user: {ex.Message}");
            }
        }

        public async Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase)
        {
            var existingUser = await _purchaseRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new PurchaseResponse("User not found");

            try
            {
                _purchaseRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new PurchaseResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public async Task<PurchaseResponse> DeleteAsync(int id)
        {
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);

            if (existingPurchase == null)
                return new PurchaseResponse("User not found");

            try
            {
                _purchaseRepository.Remove(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(existingPurchase);
            }
            catch (Exception ex)
            {
                return new PurchaseResponse($"An error occorred when deleting the user: {ex.Message}");
            }
        }
    }
}
