using UnityEngine;

namespace ShootArena.Infrastructure.Modules.CustomFactory
{
    public interface ICustomFactoryModule
    {
        public T Create<T>(string assetPath);
        public T Create<T>(string assetPath, Transform parent);
        public T Create<T>(string assetPath, Vector3 at, Quaternion rotation, Transform parent);
    }
}