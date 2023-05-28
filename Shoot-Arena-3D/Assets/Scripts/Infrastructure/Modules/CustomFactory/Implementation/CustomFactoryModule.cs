using ShootArena.Infrastructure.Modules.AssetProvider;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Modules.CustomFactory.Implementation
{
    public class CustomFactoryModule : ICustomFactoryModule
    {
        private readonly IAssetProviderModule _assetProvider = null;
        private readonly DiContainer _container = null;

        public CustomFactoryModule(DiContainer container, IAssetProviderModule assetProvider)
        {
            _assetProvider = assetProvider;
            _container = container;
        }

        public T Create<T>(string assetPath)
        {
            GameObject tempObj = _assetProvider.GetAsset<GameObject>(assetPath);
            T result = _container.InstantiatePrefabForComponent<T>(tempObj);

            return result;
        }

        public T Create<T>(string assetPath, Transform parent)
        {
            GameObject tempObj = _assetProvider.GetAsset<GameObject>(assetPath);
            T result = _container.InstantiatePrefabForComponent<T>(tempObj, parent);

            return result;
        }

        public T Create<T>(string assetPath, Vector3 at, Quaternion rotation, Transform parent)
        {
            GameObject tempObj = _assetProvider.GetAsset<GameObject>(assetPath);
            T result = _container.InstantiatePrefabForComponent<T>(tempObj, at, rotation, parent);

            return result;
        }
    }
}