using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for buttons managers controlling hacking mini-game states.
/// </summary>

public class MG_StateBase_Btn : MonoBehaviour
{
    [SerializeField] private GameObject toTurnOff;
    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private TimerController timer;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnButtonClick()
    {
        toTurnOff.SetActive(false);
    }
}
