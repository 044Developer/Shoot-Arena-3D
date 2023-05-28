namespace ShootArena.Infrastructure.Core.Arena.Data.Configuration
{
    public interface IArenaConfigurationData
    {
        public int NumberOfArenaAreas { get; }
        public float OffsetFromClosestObstacle { get; }
    }
}