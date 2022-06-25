using UnityEngine;
using UnityEngine.Events;

public abstract class Ball : MonoBehaviour
{
    public event UnityAction Died;

    public virtual void DecreaseBall(float damage)
    {
        transform.localScale -= new Vector3(damage, damage, damage);

        if (transform.localScale.z <= 0.1f)
        {
            Destroy(gameObject);
            Died?.Invoke();
        }
    }

    public virtual void IncreaseBall(float health)
    {
        transform.localScale += new Vector3(health, health, health);
    }
}
