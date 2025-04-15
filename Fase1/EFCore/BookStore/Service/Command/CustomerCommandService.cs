using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;

namespace BookStore.Service.Command;

public class CustomerCommandService : CommandService<Customer>, ICustomerCommandService
{
    public CustomerCommandService(ICustomerCommandRepository repository) : base(repository) {}
}