using MarketPlaceAPI.Product.Model;

namespace MarketPlaceAPI.Product.Interface;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProductsAsync();
    Task AddProductAsync(ProductModel Product);
    Task<bool> DeleteProductAsync(int id);
}