using Microsoft.AspNetCore.Authorization;

namespace MarketPlaceAPI.Product.Model
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "User")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}