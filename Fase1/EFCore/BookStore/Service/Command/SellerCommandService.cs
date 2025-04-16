using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Extensions;

namespace BookStore.Service.Command;

public class SellerCommandService : ISellerCommandService
{
    private readonly ISellerCommandRepository _repository;

    public SellerCommandService(ISellerCommandRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(SellerDto sellerDto)
    {
        await _repository.AddAsync(sellerDto.ToEntity());
    }

    public async Task UpdateAsync(SellerDto sellerDto)
    {
        await _repository.UpdateAsync(sellerDto.ToEntity());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}