using System;
using UnityEngine;

[RequireComponent(typeof(HingeJoint), typeof(UpperBallFinish))]
public class UpperBall : Ball
{
    [SerializeField] private MiddleBall _middleBoll;
    [SerializeField] private PlayerCollisionHandler _handler;

    private UpperBallFinish _finishBall;
    private HingeJoint _joint;

    private float _startConnectedAnchor = 0.5f; 
    private float _changeConnectedAnchor = 0.00625f;

    public event Action ChangeTransperency;
    public event Action ReachedSize; 

    private void Start()
    {
        _joint = GetComponent<HingeJoint>();
        _finishBall = GetComponent<UpperBallFinish>();
    }

    public override void DecreaseBall(float damage)
    {
        int cutDamage = 2;

        transform.localScale -= new Vector3(damage / cutDamage, damage / cutDamage, damage / cutDamage);

        if (transform.localScale.z <= 0.45f) 
        {
            ChangeTransperency?.Invoke();

            if (transform.localScale.z <= 0.4f)
            {
                ReachedSize?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }

    public void ChangeConnectedAnchor(float value) 
    {
        _joint.connectedAnchor = new Vector3(0f, value, 0f);
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _middleBoll.DamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _middleBoll.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken()
    {
        ChangeConnectedAnchor(_startConnectedAnchor -= _changeConnectedAnchor);
    }

    private void OnFinishReached()
    {
        _finishBall.enabled = true;
        enabled = false;
    }
}
