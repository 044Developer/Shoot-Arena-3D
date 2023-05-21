using System;

namespace ShootArena.Infrastructure.Modules.DeviceCheck.Data
{
    [Flags]
    public enum CurrentDeviceType
    {
        None = 0,
        PC = 1 << 1,
        Mobile = 1 << 2,
        Android = 1 << 3,
        IOS = 1 << 4,
        Editor = 1 << 5,
    }
}