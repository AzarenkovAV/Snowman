using UnityEngine;

public class СlothesHandler : ClothesHandlerAbstract
{
    [SerializeField] private Hands _scrambleHands;

    [SerializeField] private PlayerCollisionHandler _handler;
    [SerializeField] private ClothesHandlerFinish _finishHandler;

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _bottonBall.Died += OnBottonBallDied;
        _middleBall.Died += OnMiddleBallDied;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _bottonBall.Died -= OnBottonBallDied;
        _middleBall.Died -= OnMiddleBallDied;
    }

    private void OnFinishReached()
    {
        _finishHandler.enabled = true;
        enabled = false;
    }

    private void OnBottonBallDied()
    {
        _putOnHands.gameObject.SetActive(false);
        _scrambleHands.gameObject.SetActive(true);
    }

    private void OnMiddleBallDied()
    {
        _putOnHat.gameObject.SetActive(false);
        _putOnTorus.gameObject.SetActive(false);
        _scrambleHands.gameObject.SetActive(false);
    }
}
