using System;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy : IEnemyAttack
    {
        public Transform Transform { get; }
        public IEnemyConfigurationData ConfigurationData { get; }
        public IMemoryPool MemoryPool { get; }
        public void Initialize();
        public void SetEnemyDieAction(Action<IEnemy> onEnemyDieAction);
        public void SetParent(Transform parent);
        public void SetPosition(Vector3 newPosition);
        public void ActivateEnemy();
        public void DeactivateEnemy();
        public void Dispose();
    }
}