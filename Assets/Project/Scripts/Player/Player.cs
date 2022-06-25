using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerCollisionHandler _handler;

    private int _reachedFinishBoxes;

    public int ReachedFinishBoxes => _reachedFinishBoxes;
    public float Speed => _speed;

    private void OnEnable()
    {
        _handler.TouchedFinishBox += OnTouchedFinishBox;
    }

    private void OnDisable()
    {
        _handler.TouchedFinishBox -= OnTouchedFinishBox;
    }

    private void OnTouchedFinishBox()
    {
        _reachedFinishBoxes++;
    }
}
