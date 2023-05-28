namespace ShootArena.Infrastructure.Core.Player.Data.Configuration
{
    public class PlayerConfigurationData : IPlayerConfigurationData
    {
        public float PlayerMoveSpeed { get; }
        public float PlayerRotationSpeed { get; }
        public float PlayerRotationMinHeight { get; }
        public float PlayerRotationMaxHeight { get; }
        public float PlayerStartHealthValue { get; }
        public float PlayerMaxHealthValue { get; }
        public float PlayerStartStrengthValue { get; }
        public float PlayerMaxStrengthValue { get; }
        public int MinStrengthRestoreValue { get; }
        public int MaxStrengthRestoreValue { get; }
        public int HealthRestoreValue { get; }

        public PlayerConfigurationData(
            float playerMoveSpeed,
            float playerRotationSpeed,
            float playerMinRotateHeight,
            float playerMaxRotateHeight,
            float playerStartHealthValue,
            float playerMaxHealthValue,
            float playerStartStrengthValue,
            float playerMaxStrengthValue,
            int minStrengthRestoreValue,
            int maxStrengthRestoreValue,
            int healthRestoreValue)
        {
            PlayerMoveSpeed = playerMoveSpeed;
            PlayerRotationSpeed = playerRotationSpeed;
            PlayerRotationMinHeight = playerMinRotateHeight;
            PlayerRotationMaxHeight = playerMaxRotateHeight;
            PlayerStartHealthValue = playerStartHealthValue;
            PlayerMaxHealthValue = playerMaxHealthValue;
            PlayerStartStrengthValue = playerStartStrengthValue;
            PlayerMaxStrengthValue = playerMaxStrengthValue;
            MinStrengthRestoreValue = minStrengthRestoreValue;
            MaxStrengthRestoreValue = maxStrengthRestoreValue;
            HealthRestoreValue = healthRestoreValue;
        }
    }
}