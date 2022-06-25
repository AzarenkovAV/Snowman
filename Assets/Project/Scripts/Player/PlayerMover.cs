using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(Transform))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Player _player;
    private Vector3 _direction;
    private Quaternion _rotation;
    private Transform _transform;

    private void Start()
    {
        _player = GetComponent<Player>();
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 direction)
    {
        _direction.Set(direction.x, 0, direction.y);
        _direction.Normalize();
        _transform.Translate(_direction * _player.Speed * Time.deltaTime, Space.World);

        if (_direction != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(_direction, Vector3.up);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _rotation, _rotationSpeed);
        }
    }
}
