using UnityEngine;

public class Snow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
        }
    }
}
