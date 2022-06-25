using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FinishMover : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private UpperBallFinish _ball;
    [SerializeField] private float _speed = 12;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.localRotation = Quaternion.LookRotation(Vector3.forward);
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        enabled = false; 
        _ball.GameOver -= OnGameOver;
    }
}
