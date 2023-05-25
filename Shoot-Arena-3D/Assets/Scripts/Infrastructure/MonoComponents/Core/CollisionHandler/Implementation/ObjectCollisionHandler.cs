using System;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.CollisionHandler.Implementation
{
    public class ObjectCollisionHandler : MonoBehaviour, IObjectCollisionHandler
    {
        public Action<Collision> OnCollisionEnterEvent { get; set; }
        public Action<Collision> OnCollisionStayEvent { get; set; }
        public Action<Collision> OnCollisionExitEvent { get; set; }
        public Action<Collider> OnTriggerEnterEvent { get; set; }
        public Action<Collider> OnTriggerStayEvent { get; set; }
        public Action<Collider> OnTriggerExitEvent { get; set; }
        
        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterEvent?.Invoke(other);
        }

        private void OnCollisionStay(Collision other)
        {
            OnCollisionStayEvent?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitEvent?.Invoke(other);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }
    }
}