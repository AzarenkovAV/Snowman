using System;

public class MiddleBall : Ball
{
    public event Action DamageTaken;

    public override void DecreaseBall(float damage)
    {
        base.DecreaseBall(damage);

        DamageTaken?.Invoke();
    }
}
