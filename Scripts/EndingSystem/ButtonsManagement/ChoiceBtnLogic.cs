using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles ending choice buttons and passes the selected choice to the ending state controller.
/// </summary>

public class ChoiceBtnLogic : MonoBehaviour
{
    private TextMeshProUGUI _choiceText;
    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _choiceText.text = "The impostor: " + _btn.GetComponentInChildren<Text>().text;
        StateController.Instance.ManageEnding(gameObject.name);
    }
}
