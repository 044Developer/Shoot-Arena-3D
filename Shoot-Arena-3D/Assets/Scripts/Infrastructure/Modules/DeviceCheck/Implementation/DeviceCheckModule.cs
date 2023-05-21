using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using Zenject;

namespace ShootArena.Infrastructure.Modules.DeviceCheck.Implementation
{
    public class DeviceCheckModule : IDeviceCheckModule, IInitializable
    {
        public CurrentDeviceType CurrentDeviceType { get; private set; }


        public void Initialize()
        {
            CheckCurrentDevice();
        }

        private void CheckCurrentDevice()
        {
#if UNITY_ANDROID
            CurrentDeviceType = CurrentDeviceType.Mobile | CurrentDeviceType.Android;
#elif UNITY_IOS
            CurrentDeviceType = CurrentDeviceType.Mobile | CurrentDeviceType.IOS;
#elif UNITY_EDITOR
            CurrentDeviceType = CurrentDeviceType.PC  | CurrentDeviceType.Editor;
#endif
        }
    }
}