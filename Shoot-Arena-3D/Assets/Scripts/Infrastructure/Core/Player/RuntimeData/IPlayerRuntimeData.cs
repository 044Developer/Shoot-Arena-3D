using ShootArena.Infrastructure.Core.Player.Data.Control;
using ShootArena.Infrastructure.Core.Player.Data.Health;
using ShootArena.Infrastructure.Core.Player.Data.Strength;
using ShootArena.Infrastructure.Core.Player.Model;

namespace ShootArena.Infrastructure.Core.Player.RuntimeData
{
    public interface IPlayerRuntimeData
    {
        IPlayer Player { get; } 
        public PlayerHealthData HealthData { get; }
        public PlayerStrengthData PlayerStrengthData { get; }
        public PlayerControlData PlayerControlData { get; }
    }
}