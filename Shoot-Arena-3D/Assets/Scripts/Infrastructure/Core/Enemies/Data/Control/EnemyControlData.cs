using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Control
{
    public class EnemyControlData : IEnemyControlData
    {
        public EnemyType EnemyType { get; }
        public float MoveSpeed { get; }
        public float JumpHeight { get; }

        public EnemyControlData(EnemyType enemyType, float moveSpeed, float jumpHeight)
        {
            EnemyType = enemyType;
            MoveSpeed = moveSpeed;
            JumpHeight = jumpHeight;
        }
    }
}