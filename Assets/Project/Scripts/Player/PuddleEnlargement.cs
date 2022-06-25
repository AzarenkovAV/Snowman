using System.Collections;
using UnityEngine;

public class PuddleEnlargement : MonoBehaviour
{
    [SerializeField] private UpperBall _ball;
    [SerializeField] private ParticleSystem _fog;
    [SerializeField] private PlayerCollisionHandler _handler;

    private float _targetPositionY = 1.0684f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        _handler.FinishReached += OnFinishReached;
        _ball.ReachedSize += OnReachedSize;
    }

    private void OnDisable()
    {
        _handler.FinishReached -= OnFinishReached;
        _ball.ReachedSize -= OnReachedSize;
    }

    private void OnFinishReached()
    {
        enabled = false;
    }

    private void OnReachedSize()
    {
        transform.position = new Vector3(_ball.transform.position.x, _targetPositionY, _ball.transform.position.z);
        _fog.Play();

        var startIncrease = StartCoroutine(Increase());
    }

    private IEnumerator Increase()
    {
        float targetScale = 0.2f;
        float increasePerIteration = 0.005f;

        while (transform.localScale.z <= targetScale)
        {
            transform.localScale += new Vector3(increasePerIteration, increasePerIteration, increasePerIteration);
            yield return null;
        }
    }
}
