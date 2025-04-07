using MarketPlaceAPI.Product.Interface;
using MarketPlaceAPI.Product.Model;

namespace MarketPlaceAPI.Product.Infrastructure;

    public static class Endpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var productGroup = app.MapGroup("/product");

            productGroup.MapGet("/", GetAllProducts).RequireAuthorization();
            productGroup.MapPost("/", CreateProduct).RequireAuthorization("Admin");
            productGroup.MapDelete("/{id}", DeleteProduct).RequireAuthorization("Admin");
        }

        static async Task<IResult> GetAllProducts(IProductService ProductService)
        {
            var Products = await ProductService.GetAllProductsAsync();
            return TypedResults.Ok(Products);
        }

        static async Task<IResult> CreateProduct(ProductModel ProductActivity, IProductService ProductService)
        {
            await ProductService.AddProductAsync(ProductActivity);
            return TypedResults.Created($"/Products/{ProductActivity.Id}", ProductActivity);
        }

        static async Task<IResult> DeleteProduct(int id, IProductService ProductService)
        {
            var success = await ProductService.DeleteProductAsync(id);
            return success ? TypedResults.NoContent() : TypedResults.NotFound();
        }
    }
