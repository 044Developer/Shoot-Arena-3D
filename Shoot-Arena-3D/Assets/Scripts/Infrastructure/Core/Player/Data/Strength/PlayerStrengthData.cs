namespace ShootArena.Infrastructure.Core.Player.Data.Strength
{
    public class PlayerStrengthData
    {
        public float CurrentStrengthValue { get; set; }
        public float StartStrengthValue { get; }
        public float MinStrengthValue { get; }
        public float MaxStrengthValue { get; }

        public PlayerStrengthData(float startStrengthValue, float maxStrengthValue)
        {
            StartStrengthValue = startStrengthValue;
            MaxStrengthValue = maxStrengthValue;
            MinStrengthValue = 0;
        }
    }
}