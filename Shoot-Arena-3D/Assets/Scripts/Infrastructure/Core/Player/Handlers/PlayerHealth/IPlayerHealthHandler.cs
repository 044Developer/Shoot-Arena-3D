namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth
{
    public interface IPlayerHealthHandler
    {
        void SetUpPlayerHealth();
        void ReceiveDamage(float value);
        void TopUpHealth(float value);
    }
}