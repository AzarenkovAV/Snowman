using System.Collections;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _handler;
    [SerializeField] private Player _target;
    [SerializeField] private Player _changedTarget;
    [SerializeField] private UpperBall _ball;
    [SerializeField] private UpperBallFinish _finishBall;
    [SerializeField] private float _smooth;

    private Vector3 _offset;
    private Vector3 _finishOffset;
    private Vector3 _dieOffset;

    private Quaternion _startRotation;
    private Quaternion _targetRotation;
    private float _lerpDuration = 1f;

    private void Start()
    {
        _offset = new Vector3(0f, transform.position.y, transform.position.z);
        _finishOffset = new Vector3(0f, 6.4f, -8.5f);
        _dieOffset = new Vector3(0, 1.5f, -1.8724f);
        _startRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(22f, 0f, 0f);
        _smooth = _target.Speed;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _offset, _smooth * Time.deltaTime);
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _ball.ReachedSize += OnReachedSize;
        _finishBall.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _ball.ReachedSize -= OnReachedSize;
        _finishBall.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _offset = _dieOffset;
    }

    private void OnReachedSize()
    {
        _target = _changedTarget;
    }

    private IEnumerator ChangeRotate()
    {
        float timeRotate = 0f;
        float changeRotateIterration = 0.02f;

        while (timeRotate < _lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, timeRotate / _lerpDuration);
            timeRotate += changeRotateIterration; 
            yield return null;
        }
    }

    private void OnFinishReached()
    {
        _smooth = 5f;
        _offset = _finishOffset;
        var startChange = StartCoroutine(ChangeRotate());
    }
}
