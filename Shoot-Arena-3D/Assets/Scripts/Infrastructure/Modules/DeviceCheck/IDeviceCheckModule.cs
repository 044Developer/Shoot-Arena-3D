using ShootArena.Infrastructure.Modules.DeviceCheck.Data;

namespace ShootArena.Infrastructure.Modules.DeviceCheck
{
    public interface IDeviceCheckModule
    {
        public CurrentDeviceType CurrentDeviceType { get; }
        void CheckCurrentDevice();
    }
}