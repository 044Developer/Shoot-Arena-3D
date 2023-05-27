using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.Modules.UIWindows.Models;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;

namespace ShootArena.Infrastructure.Modules.UIWindows.Container.Implementation
{
    public class UIWindowsContainer : IUIWindowsContainer
    {
        private readonly ICustomLoggerModule _logger = null;
        private readonly Dictionary<UIWindowType, IWindowConfigModel> _cachedWindowConfigs = null;

        public UIWindowsContainer(ICustomLoggerModule logger)
        {
            _logger = logger;
            _cachedWindowConfigs = new Dictionary<UIWindowType, IWindowConfigModel>();
        }

        public void Initialize()
        {
            RegisterConfigs();
        }
        
        public IWindowConfigModel GetWindowConfig(UIWindowType type)
        {
            try
            {
                _cachedWindowConfigs.TryGetValue(type, out var config);
                return config;
            }
            catch (Exception exception)
            {
                _logger.LogException(exception);
                throw;
            }
        }

        private void RegisterConfigs()
        {
            RegisterNewWindowConfig(UIWindowType.Pause, "Prefabs/UI/Windows/Pause_Window", UIRootType.Windows);
            RegisterNewWindowConfig(UIWindowType.Loose, "Prefabs/UI/Windows/Lose_Window", UIRootType.Windows);
            RegisterNewWindowConfig(UIWindowType.LevelCountDown, "Prefabs/UI/Windows/LevelCountDown_Window", UIRootType.Windows);
        }

        private void RegisterNewWindowConfig(UIWindowType type, string prefabPath, UIRootType rootLayer)
        {
            _cachedWindowConfigs.Add(type, new WindowConfigModel(type, prefabPath, rootLayer));
        }
    }
}