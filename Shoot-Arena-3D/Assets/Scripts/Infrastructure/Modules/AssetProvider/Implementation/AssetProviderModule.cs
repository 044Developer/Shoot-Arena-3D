using UnityEngine;

namespace ShootArena.Infrastructure.Modules.AssetProvider.Implementation
{
    public class AssetProviderModule : IAssetProviderModule
    {
        public T GetAsset<T>(string assetPath) where T : Object
        {
            return Resources.Load<T>(assetPath);
        }
    }
}