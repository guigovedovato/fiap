using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;

namespace BookStore.Service.Command;

public class SellerCommandService : CommandService<Seller>, ISellerCommandService
{
    public SellerCommandService(ISellerCommandRepository repository) : base(repository) {}
}