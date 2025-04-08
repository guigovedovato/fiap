using MarketPlaceClient.Services;
using MarketPlaceClient.Model;

namespace MarketPlaceClient.Infrastructure;

    public static class Endpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var productGroup = app.MapGroup("/product");

            productGroup.MapGet("/", GetAllProducts);
            productGroup.MapPost("/", CreateProduct);
            productGroup.MapDelete("/{id}", DeleteProduct);
        }

        static async Task<IResult> GetAllProducts(IProductService ProductService)
        {
            var Products = await ProductService.GetAllProductsAsync();
            return TypedResults.Ok(Products);
        }

        static async Task<IResult> CreateProduct(ProductModel ProductActivity, IProductService ProductService)
        {
            var product = await ProductService.AddProductAsync(ProductActivity);
            return TypedResults.Ok(product);
        }

        static async Task<IResult> DeleteProduct(int id, IProductService ProductService)
        {
            var success = await ProductService.DeleteProductAsync(id);
            return success ? TypedResults.NoContent() : TypedResults.NotFound();
        }
    }
