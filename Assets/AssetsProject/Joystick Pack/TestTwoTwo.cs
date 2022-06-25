using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTwoTwo : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float _offset;
    [SerializeField] private bool _increase;
    [SerializeField] private bool _decrease;
    [SerializeField] private float _startScaleSphere;

    private void Update()
    {
        _offset = _sphere.transform.position.y;

        transform.localPosition = new Vector3(transform.position.x, _offset + transform.localScale.y, transform.localPosition.z);
    }
}
