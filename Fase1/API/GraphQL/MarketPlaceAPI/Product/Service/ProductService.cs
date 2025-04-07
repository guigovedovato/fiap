using MarketPlaceAPI.Product.Interface;
using MarketPlaceAPI.Product.Model;
using MarketPlaceAPI.Product.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceAPI.Product.Service;
public class ProductService(ProductRepository _productRepository) : IProductService
{
    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        return await _productRepository.Products.ToListAsync();
    }

    public async Task AddProductAsync(ProductModel product)
    {
        _productRepository.Products.Add(product);
        await _productRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        if (await _productRepository.Products.FindAsync(id) is ProductModel product)
        { 
            _productRepository.Products.Remove(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
            
        return false;
    }
}