using ShootArena.Infrastructure.Core.Player.Data.Control;
using ShootArena.Infrastructure.Core.Player.Data.Health;
using ShootArena.Infrastructure.Core.Player.Data.Strength;
using ShootArena.Infrastructure.Core.Player.Model;

namespace ShootArena.Infrastructure.Core.Player.RuntimeData
{
    public class PlayerRuntimeData : IPlayerRuntimeData
    {
        public IPlayer Player { get; set; }
        public PlayerHealthData HealthData { get; } = new PlayerHealthData();
        public PlayerStrengthData PlayerStrengthData { get;  } = new PlayerStrengthData();
        public PlayerControlData PlayerControlData { get; } = new PlayerControlData();
    }
}