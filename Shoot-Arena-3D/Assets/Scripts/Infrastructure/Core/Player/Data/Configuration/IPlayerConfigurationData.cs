namespace ShootArena.Infrastructure.Core.Player.Data.Configuration
{
    public interface IPlayerConfigurationData
    {
        public float PlayerMoveSpeed { get; }
        public float PlayerRotationSpeed { get; }
        public float PlayerRotationMinHeight { get; }
        public float PlayerRotationMaxHeight { get; }
        public float PlayerShootRate { get; }
        public float PlayerStartHealthValue { get; }
        public float PlayerMaxHealthValue { get; }
        public float PlayerStartStrengthValue { get; }
        public float PlayerMaxStrengthValue { get; }
    }
}