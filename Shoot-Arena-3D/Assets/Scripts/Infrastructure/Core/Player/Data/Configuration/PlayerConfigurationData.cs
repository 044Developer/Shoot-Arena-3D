namespace ShootArena.Infrastructure.Core.Player.Data.Configuration
{
    public class PlayerConfigurationData : IPlayerConfigurationData
    {
        public float PlayerMoveSpeed { get; }
        public float PlayerRotationSpeed { get; }
        public float PlayerShootRate { get; }
        public float PlayerStartHealthValue { get; }
        public float PlayerMaxHealthValue { get; }
        public float PlayerStartStrengthValue { get; }
        public float PlayerMaxStrengthValue { get; }

        public PlayerConfigurationData(
            float playerMoveSpeed,
            float playerRotationSpeed,
            float playerShootRate,
            float playerStartHealthValue,
            float playerMaxHealthValue,
            float playerStartStrengthValue,
            float playerMaxStrengthValue)
        {
            PlayerMoveSpeed = playerMoveSpeed;
            PlayerRotationSpeed = playerRotationSpeed;
            PlayerShootRate = playerShootRate;
            PlayerStartHealthValue = playerStartHealthValue;
            PlayerMaxHealthValue = playerMaxHealthValue;
            PlayerStartStrengthValue = playerStartStrengthValue;
            PlayerMaxStrengthValue = playerMaxStrengthValue;
        }
    }
}