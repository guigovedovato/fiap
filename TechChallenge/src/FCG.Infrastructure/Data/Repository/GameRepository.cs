using FCG.Domain.Store;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;

namespace FCG.Infrastructure.Data.Repository;

public class GameRepository(ApplicationDbContext context, BaseLogger baseLogger) : Repository<GameModel>(context, baseLogger), IGameRepository
{
}
