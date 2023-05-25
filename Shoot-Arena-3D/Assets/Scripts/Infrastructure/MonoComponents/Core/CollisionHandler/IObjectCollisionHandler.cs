using System;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.CollisionHandler
{
    public interface IObjectCollisionHandler
    {
        public Action<Collision> OnCollisionEnterEvent { get; }
        public Action<Collision> OnCollisionStayEvent { get; }
        public Action<Collision> OnCollisionExitEvent { get; }
        
        public Action<Collider> OnTriggerEnterEvent { get; }
        public Action<Collider> OnTriggerStayEvent { get; }
        public Action<Collider> OnTriggerExitEvent { get; }
    }
}