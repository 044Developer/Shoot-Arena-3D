namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar
{
    public interface IEnemyHealthBarHandler
    {
        void Tick();
        public void UpdateHealthBar();
    }
}