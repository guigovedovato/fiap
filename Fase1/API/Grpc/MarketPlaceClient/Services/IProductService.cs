using MarketPlaceClient.Model;

namespace MarketPlaceClient.Services;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProductsAsync();
    Task<ProductModel> AddProductAsync(ProductModel Product);
    Task<bool> DeleteProductAsync(int id);
}