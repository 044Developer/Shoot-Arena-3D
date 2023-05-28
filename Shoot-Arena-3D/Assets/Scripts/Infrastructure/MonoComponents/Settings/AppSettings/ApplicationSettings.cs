using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Settings.AppSettings
{
    [CreateAssetMenu(menuName = "Settings/Application", fileName = "application_settings")]
    public class ApplicationSettings : ScriptableObject
    {
        [SerializeField] private bool _overrideDeviceType = false;
        [SerializeField] private CurrentDeviceType _deviceType;

        public bool OverrideDeviceType => _overrideDeviceType;
        public CurrentDeviceType DeviceType => _deviceType;
    }
}