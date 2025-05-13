using FCG.Domain.Library;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;

namespace FCG.Infrastructure.Data.Repository;

public class LibraryRepository(ApplicationDbContext context, BaseLogger baseLogger) : Repository<LibraryModel>(context, baseLogger), ILibraryRepository
{
}
