using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private UpperBall _ball;
    [SerializeField] private UpperBallFinish _finishBall;

    [SerializeField] private Button _getButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private LevelClearUI _levelClear;
    [SerializeField] private LevelFailUI _levelFail;
    [SerializeField] private DownTextUI _text;

    private readonly float _targetPosition = 274f;
    private float _buttonTimer = 0;
    private float _textTimer = 0;

    private void Start()
    {
        _levelFail.gameObject.SetActive(false);

        _levelClear.transform.localScale = Vector3.one;
        _getButton.transform.localScale = Vector3.zero; 
        _replayButton.transform.localScale = Vector3.zero;
        _text.transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        _ball.ReachedSize += OnReachedSize;
        _finishBall.GameOver += OnEndGame;
    }

    private void OnDisable()
    {
        _ball.ReachedSize -= OnReachedSize;
        _finishBall.GameOver -= OnEndGame; 
    }

    private IEnumerator IncreaseButton(Button buttom)
    {
        float targetTime = 1f;
        float increasePerIteration = 0.08f;
        float timeOneIteration = 0.1f;

        while (_buttonTimer <= targetTime)
        {
            buttom.transform.localScale = new Vector3(buttom.transform.localScale.x + increasePerIteration,
                                                      buttom.transform.localScale.y + increasePerIteration,
                                                      buttom.transform.localScale.z + increasePerIteration);

            _buttonTimer += timeOneIteration;

            yield return null;
        }
    }

    private IEnumerator IncreaseText()
    {
        float targetTime = 1f;
        float increasePerIteration = 0.12f;
        float timeOneIteration = 0.1f;

        while (_textTimer <= targetTime)
        {
            _text.transform.localScale = new Vector3(_text.transform.localScale.x + increasePerIteration,
                                                     _text.transform.localScale.y + increasePerIteration,
                                                     _text.transform.localScale.z + increasePerIteration);

            _textTimer += timeOneIteration;

            yield return null;
        }
    }

    private IEnumerator LowerText()
    {
        float duration = 35f;

        while (_levelFail.transform.position.y >= _targetPosition)
        {
            _levelFail.transform.localPosition = Vector3.MoveTowards(new Vector3(_levelFail.transform.localPosition.x, _levelFail.transform.localPosition.y),
                                                           new Vector3(_levelFail.transform.localPosition.x, _targetPosition), duration);

            yield return null;
        }
    }

    private void OnEndGame() 
    {
        _getButton.gameObject.SetActive(true);
        _levelClear.gameObject.SetActive(true);

        var increaseText = StartCoroutine(IncreaseText());
        var increaseButton = StartCoroutine(IncreaseButton(_getButton));
    }

    private void OnReachedSize() 
    {
        _replayButton.gameObject.SetActive(true);
        _levelFail.gameObject.SetActive(true);

        var omitText = StartCoroutine(LowerText());
        var increaseButton = StartCoroutine(IncreaseButton(_replayButton));
    }
}
