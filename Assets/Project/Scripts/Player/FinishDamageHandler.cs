using System.Collections.Generic;
using UnityEngine;

public class FinishDamageHandler : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private DamageHandler _handler;
    
    private Ball _currentBall;
    private int _indexBall = 0;
    private float _changingSizePerIterration = 0.02f;
    
    private void Start()
    {
        _currentBall = _balls[0];

        _currentBall.Died += OnBallDied;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FinishBox box))
        {
            ApplyDamage(); 
        }
    }

    public void ApplyDamage()
    {
        _currentBall.DecreaseBall(_changingSizePerIterration);
    }

    private void OnBallDied()
    {
        _indexBall++;
        _currentBall.Died -= OnBallDied;
        _currentBall = _balls[_indexBall];
        _currentBall.Died += OnBallDied;

        if (_currentBall == _balls[2])
        {
            _currentBall.Died -= OnBallDied;
        }
    }
}
