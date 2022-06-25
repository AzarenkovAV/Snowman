using UnityEngine;

public class TossingClothes : MonoBehaviour
{
    [SerializeField] private MiddleBall _ball;
    [SerializeField] private PlayerCollisionHandler _handler;

    [SerializeField] private Hat _hat;
    [SerializeField] private Torus _torus;
    [SerializeField] private Hands _hands;

    [SerializeField] private float _force;

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _ball.Died += OnBallDied;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _ball.Died -= OnBallDied;
    }

    private void OnFinishReached()
    {
        enabled = false;
    }

    private void OnBallDied()
    {
        Up(_hat, _torus, _hands);
    }

    private void Up(Hat hat, Torus torus, Hands hands)
    {
        transform.position = _ball.transform.position;

        hat.gameObject.SetActive(true);
        torus.gameObject.SetActive(true);
        hands.gameObject.SetActive(true);

        hat.GetComponent<Rigidbody>().AddForce(Vector3.up * _force);
        torus.GetComponent<Rigidbody>().AddForce(Vector3.up * _force);
        hands.GetComponent<Rigidbody>().AddForce(Vector3.up * _force);
    }
}
