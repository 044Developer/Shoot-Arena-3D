namespace ShootArena.Infrastructure.Core.Player.Data.Control
{
    public class PlayerControlData
    {
        public float MoveSpeed { get; }
        public float RotationSpeed { get;}
        public float MinRotateHeight { get; }
        public float MaxRotateHeight { get; }
        public bool IsRespawning { get; set; }

        public PlayerControlData(float moveSpeed, float rotationSpeed, float minRotateHeight, float maxRotateHeight)
        {
            MoveSpeed = moveSpeed;
            RotationSpeed = rotationSpeed;
            MinRotateHeight = minRotateHeight;
            MaxRotateHeight = maxRotateHeight;
            IsRespawning = false;
        }
    }
}