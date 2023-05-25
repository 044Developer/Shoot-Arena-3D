using ShootArena.Infrastructure.Modules.DeviceCheck.Data;

namespace ShootArena.Infrastructure.Modules.DeviceCheck.Implementation
{
    public class DeviceCheckModule : IDeviceCheckModule
    {
        public CurrentDeviceType CurrentDeviceType { get; private set; }

        public void CheckCurrentDevice()
        {
#if UNITY_EDITOR
            CurrentDeviceType = CurrentDeviceType.PC | CurrentDeviceType.Editor;
#elif UNITY_IOS
            CurrentDeviceType = CurrentDeviceType.Mobile  | CurrentDeviceType.IOS;
#elif UNITY_ANDROID
            CurrentDeviceType = CurrentDeviceType.Mobile | CurrentDeviceType.Android; 
#endif
        }
    }
}