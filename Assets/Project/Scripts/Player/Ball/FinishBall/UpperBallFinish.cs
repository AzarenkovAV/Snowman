using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UpperBallFinish : Ball
{
    public event Action GameOver;

    public override void DecreaseBall(float damage)
    {
        int cutDamage = 2;

        base.DecreaseBall(damage / cutDamage);

        if (transform.localScale.z <= 0.45f)
        {
            GameOver?.Invoke();
            enabled = false;
            gameObject.SetActive(true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
