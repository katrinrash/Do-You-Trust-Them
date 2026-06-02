using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtnLogic : MonoBehaviour
{
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private TextMeshProUGUI infoText;

    private Button _button;
    private int _amountOfResets = 5; 

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);

        infoText.text = "Resets left: " + _amountOfResets;
    }

    public void SetReset(int amount)
    {
        _amountOfResets = amount;
        infoText.text = "Resets left: " + _amountOfResets;
        _button.interactable = true;
    }

    private void OnButtonClick()
    {
       if(_amountOfResets == 0 || MiniGameManager.Instance.currentCombo.Count > 0)
       {
            infoText.text = "Reset is not allowed";
            _button.interactable = false;
            return;
       }

       gridGenerator.ResetGrid();
       _amountOfResets--;
       infoText.text = "Resets left: " + _amountOfResets;
    }
}
