using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;

namespace BookStore.Service.Query;

public class CustomerQueryService : QueryService<Customer>, ICustomerQueryService
{
    public CustomerQueryService(ICustomerQueryRepository repository) : base(repository) {}
}