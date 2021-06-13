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
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
      _productRepository = productRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Product>> ListAllAsync() => await _productRepository.ListAllAsync();
    public async Task<Product> FindById(int id) => await _productRepository.FindByIdAsync(id);

    public async Task<IEnumerable<Product>> GetProductsByCompanyId(int companyId)
    {
      return await _productRepository.GetProductsByCompanyId(companyId);
    }
    public async Task<Response<Product>> SaveAsync(Product product)
    {
      try
      {
        await _productRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();

        return new Response<Product>(product);
      }
      catch (Exception ex)
      {
        return new Response<Product>($"An error occorred when saving the user: {ex.Message}");
      }
    }
    public async Task<Response<Product>> UpdateAsync(int id, Product product)
    {
      var existingProduct = await _productRepository.FindByIdAsync(id);

      if (existingProduct == null)
        return new Response<Product>("Product not found");

      try
      {
        _productRepository.Update(existingProduct);
        await _unitOfWork.CompleteAsync();

        return new Response<Product>(existingProduct);
      }
      catch (Exception ex)
      {
        return new Response<Product>($"An error occurred when updating the user: {ex.Message}");
      }
    }
    public async Task<Response<Product>> DeleteAsync(int id)
    {
      var existingProduct = await _productRepository.FindByIdAsync(id);

      if (existingProduct == null)
        return new Response<Product>("Product not found");

      try
      {
        _productRepository.Remove(existingProduct);
        await _unitOfWork.CompleteAsync();

        return new Response<Product>(existingProduct);
      }
      catch (Exception ex)
      {
        return new Response<Product>($"An error occorred when deleting the product: {ex.Message}");
      }
    }

  }
}