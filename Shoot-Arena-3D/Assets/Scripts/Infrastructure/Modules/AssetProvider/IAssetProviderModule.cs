using UnityEngine;

namespace ShootArena.Infrastructure.Modules.AssetProvider
{
    public interface IAssetProviderModule
    {
        public T GetAsset<T>(string assetPath) where T : Object;
    }
}