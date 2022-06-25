using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class BottonBall : Ball
{
    [SerializeField] private PlayerCollisionHandler _handler;

    private HingeJoint _hingeJoint;

    private float _startConnectedAnchorValue = -1f;
    private float _changePositionYValue = 0.0274f;
    private float _changeConnectedAnchorValue = 0.04f;

    private void Start() 
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    public override void IncreaseBall(float health) 
    {
        base.IncreaseBall(health);

        ChangeConnectedAnchor(_startConnectedAnchorValue -= _changeConnectedAnchorValue);
        transform.position = new Vector3(transform.position.x, transform.position.y + _changePositionYValue, transform.position.z);
    }

    public override void DecreaseBall(float damage)
    {
        base.DecreaseBall(damage);

        ChangeConnectedAnchor(_startConnectedAnchorValue += _changeConnectedAnchorValue);
        transform.position = new Vector3(transform.position.x, transform.position.y - _changePositionYValue, transform.position.z);
    }

    public void ChangeConnectedAnchor(float value) 
    {
        _hingeJoint.connectedAnchor = new Vector3(0f, value, 0f);
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
    }

    private void OnFinishReached()
    {
        _changePositionYValue = 0.01096f;
        _changeConnectedAnchorValue = 0.016f;

        _handler.FinishReached -= OnFinishReached;
    }
}
