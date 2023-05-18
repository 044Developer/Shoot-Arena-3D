using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIPanels.Models;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using Zenject;

namespace ShootArena.Infrastructure.Modules.UIPanels.Container.Implementation
{
    public class UIPanelsContainer : IUIPanelsContainer, IInitializable
    {
        private readonly ICustomLoggerModule _logger = null;
        private readonly Dictionary<UIPanelType, IPanelConfigModel> _cachedPanelConfigs = null;

        public UIPanelsContainer(ICustomLoggerModule logger)
        {
            _logger = logger;
            _cachedPanelConfigs = new Dictionary<UIPanelType, IPanelConfigModel>();
        }

        public void Initialize()
        {
            RegisterConfigs();
        }
        
        public IPanelConfigModel GetPanelConfig(UIPanelType type)
        {
            try
            {
                _cachedPanelConfigs.TryGetValue(type, out var config);
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
            RegisterNewPanelConfig(UIPanelType.Loading, "Loading_Panel", UIRootType.Panels);
            RegisterNewPanelConfig(UIPanelType.Menu, "Menu_Panel", UIRootType.Panels);
            RegisterNewPanelConfig(UIPanelType.HUD, "HUD_Panel", UIRootType.Panels);
        }

        private void RegisterNewPanelConfig(UIPanelType type, string prefabPath, UIRootType rootLayer)
        {
            _cachedPanelConfigs.Add(type, new PanelConfigModel(type, prefabPath, rootLayer));
        }
    }
}