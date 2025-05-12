using FCG.Domain.Store;
using FCG.Infrastructure.Data.Context;

namespace FCG.Infrastructure.Data.Repository;

public class GameRepository(ApplicationDbContext context) : Repository<GameModel>(context), IGameRepository
{
}
