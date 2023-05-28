namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt
{
    public interface IPlayerUltHandler
    {
        void SetUpPlayerUlt();
        void AddUltPoints(float newPoints);
        void RestoreRandomUltPoints();
        void DecreaseUltPoints(float decreaseValue);
        void UseUlt();
    }
}