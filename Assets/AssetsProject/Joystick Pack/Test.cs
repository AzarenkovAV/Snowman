using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float _startPositionY;
    [SerializeField] private float _offset;
    [SerializeField] private bool _increase;
    [SerializeField] private bool _decrease;
    [SerializeField] private float _startPosSphere;
    Rigidbody _rb;

    private void Start()
    {
        _startPositionY = transform.localPosition.y;
        _startPosSphere = _sphere.transform.localPosition.y;

        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _offset = _startPosSphere + _sphere.transform.localPosition.y;

        transform.localPosition = new Vector3(transform.localPosition.x, _startPositionY + _offset, transform.localPosition.z);

        if (_increase == true)
        {
            _sphere.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        else if (_decrease == true)
        {
            _sphere.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        }
    }
}
