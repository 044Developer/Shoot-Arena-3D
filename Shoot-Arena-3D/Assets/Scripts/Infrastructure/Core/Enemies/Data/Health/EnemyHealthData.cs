namespace ShootArena.Infrastructure.Core.Enemies.Data.Health
{
    public class EnemyHealthData
    {
        public float MaxHealth { get; }
        public float MinHealth { get; }
        public float CurrentHealth { get; set; }

        public EnemyHealthData(float maxHealth)
        {
            MaxHealth = maxHealth;
            MinHealth = 0;
            CurrentHealth = maxHealth;
        }
    }
}