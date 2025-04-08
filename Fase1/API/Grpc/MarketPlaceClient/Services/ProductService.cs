using MarketPlaceClient.Model;
using Grpc.Core;
using ProductApi;

namespace MarketPlaceClient.Services;
public class ProductService(ProductGrpc.ProductGrpcClient _client) : IProductService
{
    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        GetProductsRequest request = new GetProductsRequest();
        var response = await _client.GetProductsAsync(request);
        List<ProductModel> products = new List<ProductModel>();
        foreach (var product in response.Products)
        {
            products.Add(new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock
            });
        }
        return products;
    }

    public async Task<ProductModel> AddProductAsync(ProductModel product)
    {
        CreateProductRequest request = new CreateProductRequest
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Stock = product.Stock
        };
        var response = await _client.CreateProductAsync(request);
        return new ProductModel
        {
            Id = response.Id,
            Name = response.Name,
            Description = response.Description,
            Price = response.Price,
            Category = response.Category,
            Stock = response.Stock
        };
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        DeleteProductRequest request = new DeleteProductRequest
        {
            Id = id
        };
        var response = await _client.DeleteProductAsync(request);
        return response.Success;
    }
}