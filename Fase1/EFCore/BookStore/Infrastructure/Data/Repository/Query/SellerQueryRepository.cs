using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class SellerQueryRepository : QueryRepository<Seller>, ISellerQueryRepository
{
    public SellerQueryRepository(QueryDbContext context) : base(context) {}
}