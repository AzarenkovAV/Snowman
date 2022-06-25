using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action CollectedSnow;
    public event Action FinishReached;
    public event Action TouchedFinishBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Snow snow))
        {
            CollectedSnow?.Invoke();
        }

        if (other.gameObject.TryGetComponent(out FinishTrigger finishTrigger))
        {
            FinishReached?.Invoke();
        }

        if (other.gameObject.TryGetComponent(out FinishBox box))
        {
            TouchedFinishBox?.Invoke();
        }
    }
}
