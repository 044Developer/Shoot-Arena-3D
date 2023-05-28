namespace ShootArena.Infrastructure.Core.Player.Data.Strength
{
    public class PlayerStrengthData
    {
        public float CurrentStrengthValue { get; set; }
        public float StartStrengthValue { get; }
        public float MinStrengthValue { get; }
        public float MaxStrengthValue { get; }
        public int MinStrengthRestoreValue { get; }
        public int MaxStrengthRestoreValue { get; }

        public PlayerStrengthData(float startStrengthValue, float maxStrengthValue, int minStrengthRestoreValue, int maxStrengthRestoreValue)
        {
            StartStrengthValue = startStrengthValue;
            MaxStrengthValue = maxStrengthValue;
            MinStrengthRestoreValue = minStrengthRestoreValue;
            MaxStrengthRestoreValue = maxStrengthRestoreValue;
            MinStrengthValue = 0;
        }
    }
}