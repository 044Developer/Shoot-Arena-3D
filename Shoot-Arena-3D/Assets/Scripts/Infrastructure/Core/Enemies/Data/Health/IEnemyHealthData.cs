namespace ShootArena.Infrastructure.Core.Enemies.Data.Health
{
    public interface IEnemyHealthData
    {
        public float MaxHealth { get; }
        public float MinHealth { get; }
        public float CurrentHealth { get; set; }
    }
}