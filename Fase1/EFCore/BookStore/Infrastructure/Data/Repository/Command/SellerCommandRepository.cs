using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Command;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Command;

public class SellerCommandRepository : CommandRepository<Seller>, ISellerCommandRepository
{
    public SellerCommandRepository(CommandDbContext context) : base(context) {}
}