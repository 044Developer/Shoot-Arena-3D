namespace ShootArena.Infrastructure.Core.Player.Data.Health
{
    public class PlayerHealthData
    {
        public float CurrentHealthValue { get; set; }
        public float StartHealthValue { get; }
        public float MinHealthValue { get; }
        public float MaxHealthValue { get; }

        public PlayerHealthData(float startHealthValue, float maxHealthValue)
        {
            StartHealthValue = startHealthValue;
            MinHealthValue = 0;
            MaxHealthValue = maxHealthValue;
        }
    }
}