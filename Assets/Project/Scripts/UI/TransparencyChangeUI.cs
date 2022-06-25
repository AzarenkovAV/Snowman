using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TransparencyChangeUI : MonoBehaviour
{
    [SerializeField] private UpperBall _ball;

    private Image _image;

    private float _transperency;
    private readonly float _startAlpha = 0f;
    private readonly float _targetAlpha = 0.75f;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _startAlpha);
    }

    private void OnChangeTransperency()
    {
        var increaseAlpha = StartCoroutine(IncreaseAlpha());
    }

    private IEnumerator IncreaseAlpha()
    {
        float increaseAlpha = 0.02f;

        while (_transperency != _targetAlpha)
        {
            _transperency += increaseAlpha;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _transperency);
            yield return null;
        }
    }

    private void OnEnable()
    {
        _ball.ChangeTransperency += OnChangeTransperency;
    }

    private void OnDisable()
    {
        _ball.ChangeTransperency -= OnChangeTransperency;
    }
}
