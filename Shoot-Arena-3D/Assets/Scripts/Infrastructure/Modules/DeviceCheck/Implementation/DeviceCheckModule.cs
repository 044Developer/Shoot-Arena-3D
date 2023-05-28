using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using ShootArena.Infrastructure.MonoComponents.Settings.AppSettings;

namespace ShootArena.Infrastructure.Modules.DeviceCheck.Implementation
{
    public class DeviceCheckModule : IDeviceCheckModule
    {
        private readonly ApplicationSettings _applicationSettings = null;
        public CurrentDeviceType CurrentDeviceType { get; private set; }

        public DeviceCheckModule(ApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public void CheckCurrentDevice()
        {
            if (IsDeviceTypeOverriden())
            {
                SetDeviceTypeOverriden();
            }
            else
            {
                SetRegularDeviceType();
            }
        }

        private bool IsDeviceTypeOverriden()
        {
            return _applicationSettings.OverrideDeviceType;
        }

        private void SetDeviceTypeOverriden()
        {
            CurrentDeviceType = _applicationSettings.DeviceType;
        }

        private void SetRegularDeviceType()
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