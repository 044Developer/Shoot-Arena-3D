using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.View;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy
    {
        public IEnemyConfigurationData ConfigurationData { get; }
        public IEnemyView EnemyView { get; }
        public IMemoryPool MemoryPool { get; }
        void Die();
    }
}