using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Command;

public interface ISellerCommandService
{
    Task AddAsync(SellerDto sellerDto);
    Task UpdateAsync(SellerDto sellerDto);
    Task DeleteAsync(Guid id);
}