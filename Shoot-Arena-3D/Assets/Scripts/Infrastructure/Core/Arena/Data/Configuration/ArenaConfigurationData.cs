namespace ShootArena.Infrastructure.Core.Arena.Data.Configuration
{
    public class ArenaConfigurationData : IArenaConfigurationData
    {
        public int NumberOfArenaAreas { get; }
        public float OffsetFromClosestObstacle { get; }

        public ArenaConfigurationData(int numberOfArenaAreas, float offsetFromClosestObstacle)
        {
            NumberOfArenaAreas = numberOfArenaAreas;
            OffsetFromClosestObstacle = offsetFromClosestObstacle;
        }
    }
}