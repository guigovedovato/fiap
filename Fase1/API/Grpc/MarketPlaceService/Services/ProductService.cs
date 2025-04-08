using Grpc.Core;
using ProductApi;
using MarketPlaceService.Repository;
using MarketPlaceService.Model;
using MarketPlaceService.Extensions;

namespace MarketPlaceService.Services;

public class ProductService(ProductRepository _productRepository) : ProductGrpc.ProductGrpcBase
{
    public override async Task<ProductResponse> CreateProduct(CreateProductRequest request, ServerCallContext context)
    {
        var newProduct = new ProductResponse
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Stock = request.Stock
        };

        _productRepository.Products?.Add(newProduct.ToProduct());
        await _productRepository.SaveChangesAsync();

        return newProduct;
    }

    public override Task<ProductsResponse> GetProducts(GetProductsRequest request, ServerCallContext context)
    {
        var response = new ProductsResponse();
        response.Products.AddRange(_productRepository.Products.Select(p => p.ToProductResponse()));
        return Task.FromResult(response);
    }

    public override async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
    {
        if (await _productRepository.Products.FindAsync(request.Id) is ProductModel product)
        { 
            _productRepository.Products.Remove(product);
            await _productRepository.SaveChangesAsync();

            return new DeleteProductResponse { Success = true };
        }
            
        return new DeleteProductResponse { Success = false };
    }
}
