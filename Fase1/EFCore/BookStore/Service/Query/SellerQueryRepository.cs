using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;

namespace BookStore.Service.Query;

public class SellerQueryService : QueryService<Seller>, ISellerQueryService
{
    public SellerQueryService(ISellerQueryRepository repository) : base(repository) {}
}