using MarketPlaceAPI.Product.Interface;
using MarketPlaceAPI.Product.Model;

namespace MarketPlaceAPI.Product.GraphQL;

public class ProductMutation(IProductService _productService)
{
    public async Task<bool> AddProductAsync(ProductModel product)
    {
        await _productService.AddProductAsync(product);
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productService.DeleteProductAsync(id);
    }
}