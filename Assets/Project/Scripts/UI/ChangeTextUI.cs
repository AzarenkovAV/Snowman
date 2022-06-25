using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ChangeTextUI : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TextMeshProUGUI _newText;

    private void Start()
    {
        _newText = GetComponent<TextMeshProUGUI>();

        int count = _player.ReachedFinishBoxes * 100;
        _newText.text = "GET " + count;
    }
}
