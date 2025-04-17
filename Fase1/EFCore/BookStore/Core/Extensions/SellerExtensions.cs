using BookStore.Core.Entity;
using BookStore.Core.Dto;
using BookStore.Core.Vm;

namespace BookStore.Core.Extensions;

public static class SellerExtensions
{
    public static SellerDto ToDto(this Seller seller)
    {
        return new SellerDto
        {
            Id = seller.Id,
            CreatedAt = seller.CreatedAt,
            UpdatedAt = seller.UpdatedAt,
            Name = seller.Name,
            Email = seller.Email,
            Phone = seller.Phone,
            Address = seller.Address.ToDto()
        };
    }

    public static SellerDto ToDto(this SellerVm sellerVm)
    {
        return new SellerDto
        {
            Name = sellerVm.Name,
            Email = sellerVm.Email,
            Phone = sellerVm.Phone,
            Address = sellerVm.Address.ToDto()
        };
    }

    public static Seller ToEntity(this SellerDto seller)
    {
        return new Seller
        {
            Name = seller.Name,
            Email = seller.Email,
            Phone = seller.Phone,
            Address = seller.Address.ToEntity()
        };
    }

    public static SellerVm ToVm(this SellerDto seller)
    {
        return new SellerVm
        {
            Id = seller.Id,
            CreatedAt = seller.CreatedAt,
            UpdatedAt = seller.UpdatedAt,
            Name = seller.Name,
            Email = seller.Email,
            Phone = seller.Phone,
            Address = seller.Address.ToVm()
        };
    }
}