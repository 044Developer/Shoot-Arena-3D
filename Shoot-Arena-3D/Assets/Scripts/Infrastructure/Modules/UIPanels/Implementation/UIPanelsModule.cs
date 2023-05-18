using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.CustomFactory;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.UIPanels.Container;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIPanels.Models;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Modules.UIPanels.Implementation
{
    public class UIPanelsModule : IUIPanelsModule
    {
        private readonly IUIRoot _uiRoot = null;
        private readonly IUIPanelsContainer _panelsContainer = null;
        private readonly ICustomFactoryModule _customFactory = null;
        private readonly ICustomLoggerModule _logger = null;

        private List<IPanelConfigModel> _openedPanels = null;

        public UIPanelsModule(
            IUIRoot uiRoot,
            IUIPanelsContainer panelsContainer,
            ICustomFactoryModule customFactory,
            ICustomLoggerModule logger)
        {
            _uiRoot = uiRoot;
            _panelsContainer = panelsContainer;
            _customFactory = customFactory;
            _logger = logger;

            _openedPanels = new List<IPanelConfigModel>(4);
        }
        
        /*
         *  Public
         */

        public void ShowPanel<TPanel>(UIPanelType panelType) where TPanel : IUIView
        {
            var tempConfig = ReadConfig(panelType);

            if (tempConfig == null)
                return;
            
            SpawnImpl<TPanel>(tempConfig);
            OpenImpl(tempConfig);
        }

        public void ClosePanel(UIPanelType panelType)
        {
            if (!IsPanelOpened(panelType))
                return;

            var tempConfig = _openedPanels.Find(model => model.PanelType == panelType);
            
            CloseImpl(tempConfig);
        }
        
        /*
         *  Private
         */

        private IPanelConfigModel ReadConfig(UIPanelType panelType)
        {
            return _panelsContainer.GetPanelConfig(panelType);
        }

        private void SpawnImpl<TPanel>(IPanelConfigModel configModel) where TPanel : IUIView
        {
            var parent = ConvertRootTypeToParent(configModel.RootLayerType);
            var temp = _customFactory.Create<TPanel>(configModel.PrefabPath, parent);

            configModel.Implementation = temp;
        }

        private void OpenImpl(IPanelConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Initialize();
            configModel.Implementation.Show();
            
            _openedPanels.Add(configModel);
        }

        private void CloseImpl(IPanelConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Dispose();
            configModel.Implementation.Close();
            
            configModel.Implementation = null;
            _openedPanels.Remove(configModel);
        }

        private bool IsPanelOpened(UIPanelType panelType)
        {
            try
            {
                return _openedPanels.Find(model => model.PanelType == panelType) != null;
            }
            catch (Exception exception)
            {
                _logger.LogException(exception);
                throw;
            }
        }

        private Transform ConvertRootTypeToParent(UIRootType type)
        {
            return _uiRoot.GetRootByType(type);
        }
    }
}