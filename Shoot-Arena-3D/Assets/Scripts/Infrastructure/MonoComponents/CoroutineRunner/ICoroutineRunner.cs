using System.Collections;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}