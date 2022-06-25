using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(FinishMover))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerCollisionHandler _handler;
    [SerializeField] private float _speed;

    private FinishMover _finishMover;
    private Rigidbody _rigidbody;
    private Quaternion _rotation;
    private float _rotationSpeed = 1000f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _finishMover = GetComponent<FinishMover>();
    }

    private void Update()
    {
        Vector3 joystickInput = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y, _joystick.Vertical * _speed);

        if (joystickInput != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(joystickInput);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
    }

    private void OnFinishReached()
    {
        _finishMover.enabled = true;
        enabled = false;
    }
}
