using MarketPlaceAPI.Product.Interface;
using MarketPlaceAPI.Product.Model;

namespace MarketPlaceAPI.Product.GraphQL;

public class ProductQuery(IProductService _productService)
{
    public async Task<List<ProductModel>> GetProductsAsync()
    {
        return await _productService.GetAllProductsAsync();
    }
    
    public async Task<ProductModel?> GetProductByIdAsync(int id)
    {
        var products = await _productService.GetAllProductsAsync();
        return products?.FirstOrDefault(p => p.Id == id);
    }
}