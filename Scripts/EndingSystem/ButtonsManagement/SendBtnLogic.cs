using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the ending confirmation button and triggers the assigned ending logic.
/// </summary>

public class SendBtnLogic : MonoBehaviour
{
    private IEnding _ending;
    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Time.timeScale = 1f;
        _ending.PlayEnding();
    }

    public void SetEnding(IEnding ending)
    {
        this._ending = ending;
    }

}
