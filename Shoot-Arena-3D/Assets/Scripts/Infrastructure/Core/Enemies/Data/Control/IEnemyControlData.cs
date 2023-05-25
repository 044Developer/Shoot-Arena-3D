using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Control
{
    public interface IEnemyControlData
    {
        public EnemyType EnemyType { get; }
        public float MoveSpeed { get; }
        public float JumpHeight { get; }
    }
}