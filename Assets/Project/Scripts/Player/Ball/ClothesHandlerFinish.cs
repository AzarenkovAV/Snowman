public class ClothesHandlerFinish : ClothesHandlerAbstract
{
    private void OnEnable()
    {
        _bottonBall.Died += OnBottonBallDied;
        _middleBall.Died += OnMiddleDied;
    }

    private void OnDisable()
    {
        _bottonBall.Died -= OnBottonBallDied;
        _middleBall.Died -= OnMiddleDied;
    }

    private void OnBottonBallDied()
    {
        _putOnHands.gameObject.SetActive(false);
        _finishHands.gameObject.SetActive(true);
    }

    private void OnMiddleDied()
    {
        _putOnHat.gameObject.SetActive(false);
        _putOnTorus.gameObject.SetActive(false);
        _putOnHands.gameObject.SetActive(false);
        _finishHands.gameObject.SetActive(false);
    }
}
