using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Services.Factory
{
    public interface IEnemyFactoryService
    {
        IEnemy SpawnEnemy(EnemyType type);
    }
}