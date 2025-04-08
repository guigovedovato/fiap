using MarketPlaceService.Model;
using ProductApi;

namespace MarketPlaceService.Extensions;

public static class ProductExtensions
{
    public static ProductResponse ToProductResponse(this ProductModel product)
    {
        return new ProductResponse 
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Stock = product.Stock
        };
    }

    public static ProductModel ToProduct(this ProductResponse request)
    {
        return new ProductModel
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Stock = request.Stock
        };
    }
}