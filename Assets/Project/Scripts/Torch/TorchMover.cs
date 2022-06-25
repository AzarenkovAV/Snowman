using System.Collections;
using UnityEngine;

public class TorchMover : MonoBehaviour
{
    [SerializeField] private Transform _firstPlace;
    [SerializeField] private Transform _secondPlace;
    [SerializeField] private float _speed;

    private Transform _targetPlace;

    private void Start()
    {
        transform.position = _firstPlace.position;
        _targetPlace = _secondPlace;

        var startMover = StartCoroutine(Mover());
    }

    private IEnumerator Mover()
    {
        while (transform.position != _targetPlace.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPlace.position, _speed * Time.deltaTime);

            if (transform.position == _secondPlace.position) 
                _targetPlace = _firstPlace;
            else if (transform.position == _firstPlace.position)
                _targetPlace = _secondPlace;

            yield return null;
        }
    }
}
