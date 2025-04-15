using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;

namespace BookStore.Service.Command;

public class AddressCommandService : CommandService<Address>, IAddressCommandService 
{
    public AddressCommandService(IAddressCommandRepository repository) : base(repository) {}    
}