using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class AddressQueryRepository : QueryRepository<Address>, IAddressQueryRepository
{
    public AddressQueryRepository(QueryDbContext context) : base(context) {}

    public async Task<Address?> GetByCustomerIdAsync(Guid customerId)
    {
        return await _context.Addresses
                             .Include(a => a.Customer)
                             .FirstOrDefaultAsync(x => x.Customer.Id == customerId);
    }

    public async Task<Address?> GetBySellerIdAsync(Guid sellerId)
    {
        return await _context.Addresses
                             .Include(a => a.Seller)
                             .FirstOrDefaultAsync(x => x.Seller.Id == sellerId);
    }
}