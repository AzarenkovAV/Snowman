
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FinishDamageHandler), (typeof(PlayerCollisionHandler)))]
public class DamageHandler : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private Ball _currentBall;
    [SerializeField] private ParticleSystem _steam;
    [SerializeField] private PlayerCollisionHandler _handler;
    [SerializeField] private FinishDamageHandler _finishHandler;

    private int _indexBall = 0;
    private float _changingSizePerIterration = 0.05f;

    private void Start()
    {
        _finishHandler = GetComponent<FinishDamageHandler>();
        _handler = GetComponent<PlayerCollisionHandler>();

        _currentBall = _balls[0];

        _currentBall.Died += OnBallDied;
    }

    public void ApplyDamage()
    {
        _currentBall.DecreaseBall(_changingSizePerIterration);
        _steam.Play();
    }

    private void OnBallDied()
    {
        _indexBall++;
        _currentBall.Died -= OnBallDied;

        _currentBall = _balls[_indexBall];
        _currentBall.Died += OnBallDied;

        if (_indexBall == _balls.Count)
        {
            _currentBall.Died -= OnBallDied;
        }
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _handler.CollectedSnow += OnCollectedSnow;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _handler.CollectedSnow -= OnCollectedSnow;
    }

    private void OnCollectedSnow()
    {
        _currentBall.IncreaseBall(_changingSizePerIterration);
    }

    private void OnFinishReached()
    {
        _finishHandler.enabled = true;
        enabled = false;
    }
}
