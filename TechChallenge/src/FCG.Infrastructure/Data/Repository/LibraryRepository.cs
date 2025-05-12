using FCG.Domain.Library;
using FCG.Infrastructure.Data.Context;

namespace FCG.Infrastructure.Data.Repository;

public class LibraryRepository(ApplicationDbContext context) : Repository<LibraryModel>(context), ILibraryRepository
{
}
